using System.Runtime.Serialization;

namespace CollatzConjecture.Library
{
    [DataContract]
    public struct Output
    {
        /// <summary>
        /// Input for the test
        /// </summary>
        [DataMember]
        public Input Input { get; set; }

        /// <summary>
        /// maximum number of cycles in the set
        /// </summary>
        [DataMember]
        public long MaxCycle { get; set; }

    }
}
