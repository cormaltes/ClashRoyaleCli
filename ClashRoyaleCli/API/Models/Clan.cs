// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace ClashRoyale.API.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Clan : SearchResultClan
    {
        /// <summary>
        /// Initializes a new instance of the Clan class.
        /// </summary>
        public Clan()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Clan class.
        /// </summary>
        public Clan(string tag = default(string), string name = default(string), int? badgeId = default(int?), string type = default(string), int? clanScore = default(int?), int? requiredTrophies = default(int?), int? donationsPerWeek = default(int?), int? clanChestLevel = default(int?), int? clanChestMaxLevel = default(int?), int? members = default(int?), Location location = default(Location), string description = default(string), string clanChestStatus = default(string), int? clanChestPoints = default(int?), IList<ClanMember> memberList = default(IList<ClanMember>))
            : base(tag, name, badgeId, type, clanScore, requiredTrophies, donationsPerWeek, clanChestLevel, clanChestMaxLevel, members, location)
        {
            Description = description;
            ClanChestStatus = clanChestStatus;
            ClanChestPoints = clanChestPoints;
            MemberList = memberList;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "clanChestStatus")]
        public string ClanChestStatus { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "clanChestPoints")]
        public int? ClanChestPoints { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "memberList")]
        public IList<ClanMember> MemberList { get; set; }


        public override string ToString()
        {
            return $"{Name} = {this.ClanScore}";
        }

    }
}
