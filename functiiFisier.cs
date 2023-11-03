using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluculeseiAndrei3131b
{
    public class functiiFisier
    {
        public string numeFisier;
        public functiiFisier(string numeFisier)
        {
            this.numeFisier = numeFisier;
            
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public List<Punct> citireFisier()
        {
            List<Punct> pct = new List<Punct>();

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;

                // Read the file line by line
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    // Split the line into parts using space as the separator
                    string[] parts = linieFisier.Split(' ');

                    if (parts.Length >= 3)
                    {
                        // Parse the values for x, y, and z
                        double x, y, z;
                        if (double.TryParse(parts[0], out x) && double.TryParse(parts[1], out y) && double.TryParse(parts[2], out z))
                        {
                            Punct punct = new Punct(x, y, z);
                            pct.Add(punct);
                        }
                    }
                }
            }

            return pct;
        }

    }
}
