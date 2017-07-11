using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_application
{
    public class InputGraph
    {
        public double generations { get; set; }
        public double population { get; set; }
        public double crossoverProb { get; set; }
        public double mutationProb { get; set; }
        public double featureAMax { get; set; }
        public double featureAMin { get; set; }
        public double featureBMax { get; set; }
        public double featureBMin { get; set; }
        public double featureCMax { get; set; }
        public double featureCMin { get; set; }
        public double featureDMax { get; set; }
        public double featureDMin { get; set; }

        public InputGraph()
        {

        }
    }
}