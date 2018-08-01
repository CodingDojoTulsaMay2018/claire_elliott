using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DojoSecrets.Models
{
    public class ViewModel
    {
        public User regUser { get; set; }
        public LoginUser loginUser { get; set; }
        public Secret secret { get; set; }
        public List<Secret> secrets { get; set; }
    }
}