using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NexusSaaS.Entity
{
    public class Credential
    {
        public Credential()
        {

        }

        public Credential(int OwnerId)
        {
            this.AccessToken = Guid.NewGuid().ToString();
            this.OwnerId = OwnerId;
            this.CreatedAt = DateTime.Today;
            this.UpdatedAt = DateTime.Today;
            this.Status = CredentialStatus.Active;
            this.ExpiredAt = DateTime.Now.AddMinutes(15);
        }

        [Key]
        public string AccessToken { get; set; }
        public int OwnerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime ExpiredAt { get; set; }
        public CredentialStatus Status { get; set; }

        public bool IsValid()
        {
            return this.Status != CredentialStatus.Deactive && this.ExpiredAt > DateTime.Now;
        }
    }

    public enum CredentialStatus
    {
        Active = 1,
        Deactive = 0
    }
}
