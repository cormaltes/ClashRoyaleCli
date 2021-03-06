// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace ClashRoyaleApi.API.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class CurrentWar
    {
        /// <summary>
        /// Initializes a new instance of the CurrentWar class.
        /// </summary>
        public CurrentWar()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the CurrentWar class.
        /// </summary>
        public CurrentWar(string state = default(string), string warEndTime = default(string), CurrentWarClan clan = default(CurrentWarClan), IList<WarParticipant> participants = default(IList<WarParticipant>))
        {
            State = state;
            WarEndTime = warEndTime;
            Clan = clan;
            Participants = participants;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "warEndTime")]
        public string WarEndTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "clan")]
        public CurrentWarClan Clan { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "participants")]
        public IList<WarParticipant> Participants { get; set; }

    }
}
