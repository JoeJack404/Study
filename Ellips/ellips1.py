import numpy as np
from matplotlib import pyplot as plt
def rf(x, y):
    return x * np.power(y, 2) * (1.0 + y)
def p(x, y):
    return 1.0 + x / 2.0
def q(x, y):
    return 1.0
def f(x,y):
    return -0.5 * np.power(y, 2) - 0.5 * np.power(y, 3) - 2.0 * x - 6.0 * x * y
N = 10
M = 10
hx = 1.0 / N
hy = 1.0 / M
x = np.arange(0.0, 1.0 + hx, hx)
y = np.arange(0.0, 1.0 + hy, hy)
eps = 1e-3
udes = np.array([rf(x, yj) for yj in y])
u0 = np.zeros((len(x), len(y)))
u0[0, :] = rf(x, y[0])
u0[-1, :] = rf(x, y[-1])
u0[:, 0] = rf(x[0], y)
u0[:, -1] = rf(x[-1], y)
ulast = u0
k = 0
delta = 1.0
while delta > eps and k <= 20.0 * np.log(1 / eps) / np.power(np.pi * hx, 2):
    unew = [rf(x, y[0])]
    for j in range(1, M):
        s = [rf(x[0], y[j])]
        for i in range(1, N):
            up = p(x[i] - hx / 2.0, y[j]) * ulast[j][i - 1] / np.power(hx, 2)
            up += p(x[i] + hx / 2.0, y[j]) * ulast[j][i + 1] / np.power(hx, 2)
            up += q(x[i], y[j] - hy / 2.0) * ulast[j - 1][i] / np.power(hy, 2)
            up += q(x[i], y[j] + hy / 2.0) * ulast[j + 1][i] / np.power(hy, 2)
            up += f(x[i], y[j])
            down = (p(x[i] - hx / 2.0, y[j]) + p(x[i] + hx / 2.0, y[j])) / np.power(hx, 2)
            down += (q(x[i], y[j] - hy / 2.0) + q(x[i], y[j] + hy / 2.0)) / np.power(hy, 2)
            s.append(up / down)
        s.append(rf(x[-1], y[j]))
        unew.append(np.array(s))
    unew.append(rf(x, y[-1]))
    ulast = unew
    k += 1
    delta = np.linalg.norm(ulast - udes) / np.linalg.norm(u0 - udes)

print('k ', k)
print('delta ', delta)
print('norm_iteration', np.linalg.norm(ulast - udes))
uzlast = u0
k = 0
delta = 1.0
while delta > eps and k <= 10.0 * np.log(1/eps)/np.power(np.pi * hx, 2):
    uznew = [rf(x, y[0])]
    for j in range(1, M):
        s = [rf(x[0], y[j])]
        for i in range(1, N):
            up = p(x[i] - hx / 2.0, y[j]) * s[i-1] / np.power(hx, 2)
            up += p(x[i] + hx / 2.0, y[j]) * uzlast[j][i+1] / np.power(hx, 2)
            up += q(x[i], y[j] - hy / 2.0) * uznew[j-1][i] / np.power(hy, 2)
            up += q(x[i], y[j] + hy / 2.0) * uzlast[j+1][i] / np.power(hy, 2)
            up += f(x[i], y[j])
            down = (p(x[i] - hx / 2.0, y[j]) + p(x[i] + hx / 2.0, y[j])) / np.power(hx, 2)
            down += (q(x[i], y[j] - hy / 2.0) + q(x[i], y[j] + hy / 2.0)) / np.power(hy, 2)
            s.append(up / down)
        s.append(rf(x[-1], y[j]))
        uznew.append(np.array(s))
    uznew.append(rf(x, y[-1]))
    uzlast = uznew
    k += 1
    delta = np.linalg.norm(uzlast - udes) / np.linalg.norm(u0 - udes)

print('k ', k)
print('delta ', delta)
print('norm_Zeidel', np.linalg.norm(uzlast - udes))
print('kmax ', int(2 * np.log(1/eps) / np.power(np.pi / N, 2)))
plt.plot(y, udes[:][N//2], lw=0.75, color='red', label='real')
plt.plot(y, ulast[:][N//2], lw=0.75, color='green', label='iteration')
plt.plot(y, uzlast[:][N//2], lw=0.75, color='blue', label='Zeidel')
plt.legend()
plt.show()
plt.close()
