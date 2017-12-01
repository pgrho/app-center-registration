using System;
using System.ComponentModel.DataAnnotations;

namespace Shipwreck.AppCenterRegistration.Models
{
    public class ErrorViewModel : ViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}