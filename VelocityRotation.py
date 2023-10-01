from astropy.io import fits
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd

# Открываем FITS файл
hdul = fits.open('D:\\obs_0207\\out\\U4892_vr.fts')
data = hdul[0].data
hdul.close()

# Граничные точки 
x = np.array([110, 123])
y = np.array([76, 90])

# Массивы значений
x_values = [x[0]]
y_values = [y[0]]

values = [data[y[0], x[0]]]
        
# Размер шагов
if (abs(x[1] - x[0]) > abs(y[1] - y[0])):
    stepx = ((np.sqrt((x[1] - x[0]) ** 2 + (abs(y[1] - y[0]) ** 2)) // abs(y[1] - y[0]))) 
    stepy = (abs(y[1] - y[0])) // (abs(x[1] - x[0]) / stepx)
    if(stepy < 1):
        stepy = 1 

else:  
    stepy = ((np.sqrt((y[1] - y[0]) ** 2 + (abs(x[1] - x[0]) ** 2)) // abs(x[1] - x[0])))
    stepx = ((abs(x[1] - x[0])) // (abs(y[1] - y[0]) / stepy))
    if(stepx < 1):
        stepx = 1

x_inter = [x[0]]
k = x[0]
l = abs(x[1] - x[0]) / 50

while (k < x[1]):
    k = k + l
    x_inter.append(k)

while (x[0] < x[1]):
    x[0] = x[0] + stepx
    y[0] = y[0] + stepy
    x_values.append(x[0])
    y_values.append(y[0])
    values.append(data[y[0], x[0]])

print(stepx, stepy)
values_inter = np.interp(x_inter, x_values, values)


print(values_inter)
print(x_inter)

# Перевод в расстояние от центра
r = x_inter - (abs(x_inter[-1] + x_inter[0]) / 2)
r =  r * np.sqrt(((abs(y_values[-1] - y_values[0]) / abs(x_values[-1] - x_values[0])) ** 2) + 1)
r = r * 0.714
print((np.arctan(abs(y_values[-1] - y_values[0]) / abs(x_values[-1] - x_values[0])) * 180 / np.pi))

# Строим график
graph, (plot) = plt.subplots()
plot.plot(r, values_inter)
plot.set_xlabel('r')
plot.set_ylabel('Velocity')
plot.set_title('Rotation')

df = pd.read_csv('UGC4892_Points.csv', sep=';')
x_point = df['x']
y_point = df['y']
plot.scatter(x_point, y_point)
#plot.invert_xaxis()
plt.show()
print(y_values)

