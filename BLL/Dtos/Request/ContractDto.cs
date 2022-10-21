using System;
using System.Collections.Generic;

namespace BLL.Dtos.Request
{
    public class ContractDto
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public string ClientName { get; set; }
        public string ClientOrganizationNumber { get; set; }
        public string ClientPhone { get; set; }
        public string ClientAdress { get; set; }
        public string ClientPostcode { get; set; }
        public string ClientEmail { get; set; }
        public string ContractorName { get; set; }
        public string ContractorOrganizationNumber { get; set; }
        public string ContractorPhone { get; set; }
        public string ContractorAdress { get; set; }
        public string ContractorPostcode { get; set; }
        public string ContractorEmail { get; set; }
        public bool? IsCurrentBookkeeping { get; set; }
        public bool? IsVataccounting { get; set; }
        public bool? IsFinancialStatement { get; set; }
        public bool? IsCustomerInvoices { get; set; }
        public bool? IsVendorInvoice { get; set; }
        public bool? IsEconomicReport { get; set; }
        public bool? IsDeclaration { get; set; }
        public bool? IsPayrollAdministration { get; set; }
        public bool? IsAnnualAccounting { get; set; }
        public bool? FromAndOn { get; set; }
        public bool? TillDate { get; set; }
        public bool? UntilFurtherNotice { get; set; }
        public string? TerminationTime { get; set; }
        public bool? IsFixedPrice { get; set; }
        public string? ValueFixedPrice { get; set; }
        public bool? IsHourlyRate { get; set; }
        public string? ValueHourlyRate { get; set; }
        public bool? IsPaymentAgainstInvoice { get; set; }
        public bool? IsMonthly { get; set; }
        public bool? IsQuarterly { get; set; }
        public bool? IsCompensationIncludesCost { get; set; }
        public bool? IsAdditionToCompensation { get; set; }
        public string? ValueAdditionToCompensation { get; set; }
        public string SignedPrincipalPlace { get; set; }
        public string SignedPrincipalDate { get; set; }
        public string SignedPrincipalName { get; set; }
        public string SignedPrincipalPosition { get; set; }
        public string SignedAgencyPlace { get; set; }
        public string SignedAgencyDate { get; set; }
        public string SignedAgencyName { get; set; }
        public string SignedAgencyPosition { get; set; }
    }
}
