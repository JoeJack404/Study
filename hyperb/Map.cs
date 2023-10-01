using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hyperb
{
    public class Map
    {
        private const int N = 100;
        private const double h = 0.01;
        private const double T = 0.1;
        private static double tau = 0.16 * Math.Pow(h, 2);
        //private static double tau = 0.001;
        private const double alpha1 = 1;
        private const double alpha2 = 0;
        private const double beta1 = 1;
        private const double beta2 = 1;
        private double[] t = new double[M];
        private double[] x = new double[N];
        private double[,] u = new double[N, M];
        private double[,] u0 = new double[N, M];
        private double[,] u1 = new double[N, M];
        private double[,] u2 = new double[N, M];
        private double[] A = new double[N];
        private double[] B = new double[N];
        private double[] C = new double[N];
        private double[] G = new double[N];
        private static int M { get { return (int)Math.Round(T / tau); } }

        private void setx()
        {
            for (int i = 0; i < 100; i++)
            {
                x[i] = h * i;
            }
        }

        private void sett()
        {
            for (int i = 0; i < M; i++)
            {
                t[i] = tau * i;
            }
        }
        private double alpha(double t)
        {
            return Math.Pow(t, 3);
        }

        private double beta(double t)
        {
            return 4 + Math.Pow(t, 3);
        }

        private void setui0()
        {
            for (int i = 0; i < 100; i++)
            {
                u[i, 0] = Math.Pow(x[i], 3);
                u0[i, 0] = Math.Pow(x[i], 3);
                u1[i, 0] = Math.Pow(x[i], 3);
                u2[i, 0] = Math.Pow(x[i], 3);
                u[i, 1] = Math.Pow(x[i], 3);
                u0[i, 1] = Math.Pow(x[i], 3);
                u1[i, 1] = Math.Pow(x[i], 3);
                u2[i, 1] = Math.Pow(x[i], 3);
            }
        }

        private double f(double x, double t)
        {
            return 6 * t - (9 * Math.Pow(x, 2)) - (12 * x);
        }

        private double p(double x)
        {
            return x + 2;
        }

        private double Lu(int i, int k, double[,] u)
        {
            return (p((x[i + 1] + x[i]) / 2) * (u[i + 1, k] - u[i, k]) - (p((x[i] + x[i - 1]) / 2) * (u[i, k] - u[i - 1, k]))) / Math.Pow(h, 2);
        }

        private void setu0k(int k)
        {
            u[0, k] = alpha(t[k]);
        }

        private void setunk(int k)
        {
            u[N - 1, k] = (beta(t[k]) * 2 * h + (4 * u[N - 2, k]) - u[N - 3, k]) / (2 * h + 3);
        }

        public void solutionu()
        {
            for (int k = 1; k < M - 1; k++)
            {
                for (int i = 1; i < 99; i++)
                {
                    u[i, k + 1] = 2 * u[i, k] - u[i, k - 1] + (Math.Pow(tau, 2) * (Lu(i, k - 1, u) + f(x[i], t[k - 1])));
                }
                setu0k(k + 1);
                setunk(k + 1);
            }
        }

        private double[] prog(double[] a, double[] b, double[] c, double[] rpart)
        {
            double[] d = rpart;
            int n = d.Length;
            double[] alph = new double[n];
            double[] bet = new double[n];
            double[] sol = new double[n];
            alph[0] = c[0] / b[0];
            bet[0] = -d[0] / b[0];
            for (int i = 1; i < n; i++)
            {
                alph[i] = c[i] / (b[i] - a[i] * alph[i - 1]);
                bet[i] = (a[i] * bet[i - 1] - d[i]) / (b[i] - a[i] * alph[i - 1]);
            }
            sol[n - 1] = bet[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                sol[i] = alph[i] * sol[i + 1] + bet[i];
            }
            return sol;
        }

        public void solutionu0()
        {
            for (int k = 1; k < M - 1; k++)
            {
                for (int i = 1; i < N - 1; i++)
                {
                    u0[i, k + 1] = 2* u0[i, k] - u0[i, k - 1] + (Math.Pow(tau, 2) * (Lu(i, k - 1, u0) + f(x[i], t[k - 1])));
                }
                u0[0, k + 1] = (alpha(t[k + 1]) * h + alpha2 * u0[1, k + 1]) / (alpha1 * h + alpha2);
                u0[N - 1, k + 1] = (beta(t[k + 1]) * h + beta2 * u0[N - 2, k + 1]) / (beta1 * h + beta2);
            }
        }

        public void solutionu1()
        {
            for (int k = 1; k < M - 1; k++)
            {
                for (int i = 1; i < N - 1; i++)
                {
                    A[i] = p((x[i] + x[i - 1]) / 2) / Math.Pow(h, 2) * 0.5;
                    B[i] = (p((x[i] + x[i - 1]) / 2) + p((x[i + 1] + x[i]) / 2)) / Math.Pow(h, 2) * 0.5 + (1 / Math.Pow(tau, 2));
                    C[i] = p((x[i + 1] + x[i]) / 2) / Math.Pow(h, 2) * 0.5;
                    G[i] = (-2 * u1[i, k] + u1[i, k - 1]) / Math.Pow(tau, 2) - 0.5 * Lu(i, k - 1, u1) - f(x[i], t[k]);
                }
                B[0] = -(h * alpha1 + alpha2);
                C[0] = -alpha2;
                G[0] = alpha(t[k + 1]) * h;
                A[N - 1] = -beta2;
                B[N - 1] = -(h * beta1 + beta2);
                G[N - 1] = beta(t[k + 1]) * h;
                double[] getsol = prog(A, B, C, G);
                for (int i = 0; i < N; i++)
                {
                    u1[i, k + 1] = getsol[i];
                }
            }
        }

        public void solutionu2()
        {
            for (int k = 1; k < M -1; k++)
            {
                for (int i = 1; i < N - 1; i++)
                {
                    A[i] = (p((x[i] + x[i - 1]) / 2) / Math.Pow(h, 2)) * 0.25;
                    B[i] = ((p((x[i] + x[i - 1]) / 2) + p((x[i + 1] + x[i]) / 2)) / Math.Pow(h, 2)) * 0.25 + (1 / Math.Pow(tau, 2));
                    C[i] = (p((x[i + 1] + x[i]) / 2) / Math.Pow(h, 2)) * 0.25;
                    G[i] = (-2 * u2[i, k] + u2[i, k - 1]) / Math.Pow(tau, 2) - 0.5 * Lu(i, k, u2) - 0.25 * Lu(i, k - 1, u2) - f(x[i], t[k]);
                }
                B[0] = -(h * alpha1 + alpha2);
                C[0] = -alpha2;
                G[0] = alpha(t[k + 1]) * h;
                A[N - 1] = -beta2;
                B[N - 1] = -(h * beta1 + beta2);
                G[N - 1] = beta(t[k + 1]) * h;
                double[] getsol = prog(A, B, C, G);
                for (int i = 0; i < N; i++)
                {
                    u2[i, k + 1] = getsol[i];
                }
            }
        }

        public void solution()
        {
            setx();
            sett();
            setui0();
            solutionu();
            solutionu0();
            solutionu1();
            solutionu2();
            double[] r = new double[N];
            double[] u_ = new double[N];
            double[] u_0 = new double[N];
            double[] u_1 = new double[N];
            double[] u_2 = new double[N];
            for (int i = 0; i < N; i++)
            {
                r[i] = Math.Pow(x[i], 3) + Math.Pow(0.1, 3);
                u_[i] = u[i, M - 1];
                u_0[i] = u0[i, M - 1];
                u_1[i] = u1[i, M - 1];
                u_2[i] = u2[i, M - 1];
            }
            var plt = new ScottPlot.Plot(400, 300);
            plt.AddScatter(x, r);
            plt.AddScatter(x, u_);
            plt.AddScatter(x, u_0);
            plt.AddScatter(x, u_1);
            plt.AddScatter(x, u_2);
            new ScottPlot.FormsPlotViewer(plt).ShowDialog();
        }
    }
}
