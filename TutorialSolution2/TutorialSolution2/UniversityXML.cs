using System;
using System.Collections.Generic;
using System.Text;

namespace TutorialSolution2
{
    class UniversityXML
    {
        [JsonPropertyName("university")]
        public University University { get; set; }
    }
}
