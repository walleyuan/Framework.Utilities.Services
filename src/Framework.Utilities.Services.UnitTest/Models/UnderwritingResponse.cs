using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Utilities.Services.UnitTest.Models
{
    using Newtonsoft.Json;

    public class UnderwritingResponse
    {
        /// <summary>
        /// Gets or sets the application id.
        /// </summary>
        [JsonProperty("ApplicationId")]
        public int ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the member date of birth.
        /// </summary>
        [JsonProperty("MemberDateOfBirth")]
        public DateTime? MemberDateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the member surname.
        /// </summary>
        [JsonProperty("MemberSurname")]
        public string MemberSurname { get; set; }

        /// <summary>
        /// Gets or sets the member given names.
        /// </summary>
        [JsonProperty("MemberGivenNames")]
        public string MemberGivenNames { get; set; }

        /// <summary>
        /// Gets or sets the member gender.
        /// </summary>
        [JsonProperty("MemberGender")]
        public string MemberGender { get; set; }

        /// <summary>
        /// Gets or sets the fund contact name.
        /// </summary>
        [JsonProperty("FundContactName")]
        public string FundContactName { get; set; }

        /// <summary>
        /// Gets or sets the admin contact name.
        /// </summary>
        [JsonProperty("AdminContactName")]
        public string AdminContactName { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [JsonProperty("Status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the amount type.
        /// </summary>
        [JsonProperty("AmountType")]
        public string AmountType { get; set; }

        /// <summary>
        /// Gets or sets the occupation category.
        /// </summary>
        [JsonProperty("OccupationCategory")]
        public string OccupationCategory { get; set; }

        /// <summary>
        /// Gets or sets the date first requested.
        /// </summary>
        [JsonProperty("DateFirstRequested")]
        public DateTime? DateFirstRequested { get; set; }

        /// <summary>
        /// Gets or sets the decision.
        /// </summary>
        [JsonProperty("Decision")]
        public string Decision { get; set; }

        /// <summary>
        /// Gets or sets the date of issue.
        /// </summary>
        [JsonProperty("DateOfIssue")]
        public DateTime? DateOfIssue { get; set; }

        /// <summary>
        /// Gets or sets the expiry date.
        /// </summary>
        [JsonProperty("ExpiryDate")]
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets the maz id.
        /// </summary>
        [JsonProperty("MazId")]
        public int? MazId { get; set; }

        /// <summary>
        /// Gets or sets the scheme number.
        /// </summary>
        [JsonProperty("SchemeNumber")]
        public string SchemeNumber { get; set; }

        /// <summary>
        /// Gets or sets the hlra member number.
        /// </summary>
        [JsonProperty("HlraMemberNumber")]
        public string HlraMemberNumber { get; set; }

        /// <summary>
        /// Gets or sets the fund member number.
        /// </summary>
        [JsonProperty("FundMemberNumber")]
        public string FundMemberNumber { get; set; }

        /// <summary>
        /// Gets or sets the scheme short name.
        /// </summary>
        [JsonProperty("SchemeShortName")]
        public string SchemeShortName { get; set; }

        /// <summary>
        /// Gets or sets the sub scheme short name.
        /// </summary>
        [JsonProperty("SubschemeShortName")]
        public string SubschemeShortName { get; set; }

        /// <summary>
        /// Gets or sets the voluntary or compulsary.
        /// </summary>
        [JsonProperty("VoluntaryOrCompulsary")]
        public string VoluntaryOrCompulsary { get; set; }

        /// <summary>
        /// Gets or sets the dollars or units.
        /// </summary>
        [JsonProperty("DollarsOrUnits")]
        public string DollarsOrUnits { get; set; }

        /// <summary>
        /// Gets or sets the general comments.
        /// </summary>
        [JsonProperty("GeneralComments")]
        public string GeneralComments { get; set; }

        /// <summary>
        /// Gets or sets the has previously issued advice.
        /// </summary>
        [JsonProperty("HasPreviouslyIssuedAdvice")]
        public bool? HasPreviouslyIssuedAdvice { get; set; }

        /// <summary>
        /// Gets or sets the previous movement code.
        /// </summary>
        [JsonProperty("PreviousMovementCode")]
        public string PreviousMovementCode { get; set; }

        /// <summary>
        /// Gets or sets the link id.
        /// </summary>
        [JsonProperty("LinkId")]
        public string LinkId { get; set; }

        /// <summary>
        /// Gets or sets the member tracking information.
        /// </summary>
        [JsonProperty("MemberTrackingInformation")]
        public MemberTrackingInformation MemberTrackingInformation { get; set; }

        /// <summary>
        /// Gets or sets the information required.
        /// </summary>
        [JsonProperty("InformationRequired")]
        public List<InformationRequired> InformationRequired { get; set; }

        /// <summary>
        /// Gets or sets the movements.
        /// </summary>
        [JsonProperty("Movements")]
        public List<Movements> Movements { get; set; }
    }

    public class Movements
    {
        public int MovementId { get; set; }
        public DateTime ActionDate { get; set; }
        public string ActionCode { get; set; }
        public string Movement { get; set; }
        public string Notes { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public DateTime? FollowUpDateCompleted { get; set; }
        public string Status { get; set; }
        public string UserFullName { get; set; }
    }

    /// <summary>
    /// The member tracking information.
    /// </summary>
    public class MemberTrackingInformation
    {
        /// <summary>
        /// Gets or sets the link id.
        /// </summary>
        [JsonProperty("LinkID")]
        public int LinkId { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the home number.
        /// </summary>
        public string HomeNumber { get; set; }

        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the work phone.
        /// </summary>
        public string WorkPhone { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether track online.
        /// </summary>
        public bool TrackOnline { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether using SMS.
        /// </summary>
        public bool UsingSMS { get; set; }

        /// <summary>
        /// Gets or sets the using email.
        /// </summary>
        public string UsingEmail { get; set; }

        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the create user id.
        /// </summary>
        public string CreateUserID { get; set; }

        /// <summary>
        /// Gets or sets the create source.
        /// </summary>
        public string CreateSource { get; set; }

        /// <summary>
        /// Gets or sets the last mod date.
        /// </summary>
        public DateTime LastModDate { get; set; }

        /// <summary>
        /// Gets or sets the last mod user id.
        /// </summary>
        public string LastModUserID { get; set; }
    }


    public class InformationRequired
    {
        public int InformationItemId { get; set; }
        public string Category { get; set; }
        public string Notes { get; set; }
        public DateTime? DateRequested { get; set; }
        public DateTime? DateReceived { get; set; }
        public string SuppliedBy { get; set; }
        public string InstructionHtml { get; set; }
    }
}
