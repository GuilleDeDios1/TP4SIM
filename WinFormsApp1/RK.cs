using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class RK
    {
        public float Derivative(float t,float coefA,float coefB)
        {
            return (coefA * (float) Math.Sqrt(t + coefB));
        }

        public float RungeKutta4(float t0, float y0, float h, float C,float coefA,float coefB)
        {
            float t = t0;
            float y = y0;

            while (y <= C)
            {
                float k1 = h * Derivative(t,coefA,coefB);
                float k2 = h * Derivative(t + h / 2.0f, coefA, coefB);
                float k3 = h * Derivative(t + h / 2.0f, coefA, coefB);
                float k4 = h * Derivative(t + h, coefA, coefB);

                y += (k1 + 2 * k2 + 2 * k3 + k4) / 6.0f;
                t += h;

                if (y > C)
                    break;
            }

            return t;
        }
        public RK() { }
    }
}
