using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traff0
{
    class CommonCalculatingFormulas
    {
        public float CalculatingNumberOfWindings(float k, float voltage, float section, float induction)
        {
            return (float)Math.Round((voltage * k) / ((4.44 * 50) * (induction * section)) * 10000) + 1;
        }

        public float CalculatingDiameter(float amperage, float density)
        {
            float result = 0.03558f * (float)Math.Sqrt((amperage * 1000) / density);

            return result;
        }

        public float PickNearestDiameterOfWire(float diameter)
        {
            float result = 0;

            for (int i = 0; i < wireDiameters.Count; i++)
            {
                if (wireDiameters[i] >= diameter)
                {
                    result = wireDiameters[i];
                    break;
                }
            }

            return result;
        }

        private List<float> wireDiameters = new List<float>
        {
            0.04f, 0.05f, 0.06f, 0.07f, 0.08f, 0.09f, 0.10f, 0.11f, 0.12f,
            0.13f, 0.14f, 0.15f, 0.16f, 0.17f, 0.18f, 0.19f, 0.20f, 0.21f, 0.22f, 0.23f, 0.24f,
            0.25f, 0.26f, 0.27f, 0.28f, 0.29f, 0.30f, 0.32f, 0.34f, 0.36f, 0.38f, 0.44f, 0.45f,
            0.50f, 0.55f, 0.60f, 0.65f, 0.70f, 0.75f, 0.80f, 0.85f, 0.90f, 0.95f, 1.00f, 1.04f,
            1.08f, 1.12f, 1.16f, 1.20f, 1.25f, 1.30f, 1.35f, 1.40f, 1.45f, 1.50f, 1.56f, 1.62f,
            1.68f, 1.74f, 1.81f, 1.88f, 1.95f, 2.02f
        };

        private List<int> numberOnWindings = new List<int>
        {
            25100, 18500, 12600, 10050, 8200, 6650, 5650, 4500, 3900,
            3100, 3000, 2720, 2400, 2120, 1940, 1750, 1600, 1420, 1320, 1220, 1130,
            1050, 960, 900, 850, 800, 750, 650, 580, 520, 470, 430, 335, 280, 225,
            195, 170, 148, 126, 112, 102, 91, 81, 75, 73, 70, 65, 60, 55, 50, 45,
            41, 38, 36, 33, 31, 28, 25, 23, 17, 15, 14, 12
        };

        public float GetTheBiggestWireDiameter
        {
            get
            {
                int lastIndex = this.wireDiameters.Count - 1;
                return this.wireDiameters[lastIndex];
            }
        }
    }
}
