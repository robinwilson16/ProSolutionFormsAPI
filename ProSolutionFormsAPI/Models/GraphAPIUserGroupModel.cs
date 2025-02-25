using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProSolutionFormsAPI.Models
{
    [NotMapped]
    [Keyless]
    public class GraphAPIUserGroupModel
    {
        public string? ID { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public string? Classification { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string[]? CreationOptions { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public DateTime? ExpirationDateTime { get; set; }
        public string[]? GroupTypes { get; set; }
        public bool? IsAssignableToRole { get; set; }
        public string? Mail { get; set; }
        public bool? MailEnabled { get; set; }
        public string? MailNickname { get; set; }
        public bool? IsMemberManagementRestricted { get; set; }
        public string? MembershipRule { get; set; }
        public string? MembershipType { get; set; }
        public string? MembershipRuleProcessingState { get; set; }
        public string? OnPremisesDomainName { get; set; }
        public DateTime? OnPremisesLastSyncDateTime { get; set; }
        public string? OnPremisesNetBiosName { get; set; }
        public string? OnPremisesSamAccountName { get; set; }
        public string? OnPremisesSecurityIdentifier { get; set; }
        public bool? OnPremisesSyncEnabled { get; set; }
        public string? PreferredDataLocation { get; set; }
        public string? PreferredLanguage { get; set; }
        public string[]? ProxyAddresses { get; set; }
        public DateTime? RenewedDateTime { get; set; }
        public string[]? ResourceBehaviorOptions { get; set; }
        public string[]? ResourceProvisioningOptions { get; set; }
        public bool? SecurityEnabled { get; set; }
        public string? SecurityIdentifier { get; set; }
        public string? Theme { get; set; }
        public string? UniqueName { get; set; }
        public string? Visibility { get; set; }
        public virtual ICollection<GraphAPIUserGroupOnPremisesProvisioningErrorModel>? OnPremisesProvisioningErrors { get; set; }
        public virtual ICollection<GraphAPIUserGroupServiceProvisioningErrorModel>? ServiceProvisioningErrors { get; set; }
    }
}
