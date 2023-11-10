﻿/*
 * Author  : Ahmed Moosa
 * Email   : ahmed_moosa83@hotmail.com
 * LinkedIn: https://www.linkedin.com/in/ahmoosa/
 * Date    : 26/9/2022
 */
using ZATCA.SDK.Helpers.Zatca;
using ZATCA.SDK.Helpers.Zatca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ZATCA.SDK.Helpers.Zatca.Helpers
{
    public class ZatcaAPICaller : IZatcaAPICaller
    {
        public async Task<InvoiceModelResult> ReportSingleInvoiceAsync(InputInvoiceModel model, int clearanceStatus)
        {
            if (clearanceStatus == 1)
            {
                return await ClearSingleInvoiceAsync(model, 1);
            }
            var headers = new Dictionary<string, string>();
            headers.Add("Clearance-Status", clearanceStatus.ToString());
            return ZatcaHttpClient.PostAsync<InvoiceModelResult, InputInvoiceModel>("invoices/reporting/single", model, headers, true);
        }

        public async Task<InvoiceModelResult> ClearSingleInvoiceAsync(InputInvoiceModel model, int clearanceStatus)
        {
            var headers = new Dictionary<string, string>();
            headers.Add("Clearance-Status", clearanceStatus.ToString());
            return ZatcaHttpClient.PostAsync<InvoiceModelResult, InputInvoiceModel>("invoices/clearance/single", model, headers, true);
        }

        public async Task<ComplianceModelResult> CompleteComplianceCSIDAsync(InputComplianceModel model, string otp)
        {
            var headers = new Dictionary<string, string>();
            headers.Add("OTP", otp.ToString());
            return ZatcaHttpClient.PostAsync<ComplianceModelResult, InputComplianceModel>("compliance", model, headers);
        }

        public async Task<InvoiceModelResult> PerformComplianceCheckAsync(InputInvoiceModel model)
        {
            return ZatcaHttpClient.PostAsync<InvoiceModelResult, InputInvoiceModel>("compliance/invoices", model, null, true);
        }

        public async Task<ComplianceModelResult> OnboardingCSIDAsync(InputCSIDModel model)
        {
            return ZatcaHttpClient.PostAsync<ComplianceModelResult, InputCSIDModel>("production/csids", model, null, true);
        }

        public async Task<ComplianceModelResult> RenewalCSIDAsync(InputComplianceModel model, string otp)
        {
            var headers = new Dictionary<string, string>();
            headers.Add("OTP", otp.ToString());
            return ZatcaHttpClient.PostAsync<ComplianceModelResult, InputComplianceModel>("production/csids", model, headers, true, true);
        }
    }
}
