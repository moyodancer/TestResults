using System.Runtime.Serialization;

namespace CollatzConjecture.Library
{
    [DataContract]
    public struct Input
    {
        /// <summary>
        /// represents the starting point of our input, i in the coding challenge
        /// </summary>
        [DataMember]
        public long Start { get; set; }

        /// <summary>
        /// represents the end point of our input, j in the coding challenge
        /// </summary>
        [DataMember]
        public long End { get; set; }
    }
}
