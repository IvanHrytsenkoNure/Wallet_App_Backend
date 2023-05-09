using System.ComponentModel.DataAnnotations;

namespace Wallet_App_Backend.Data.Common
{
    public abstract class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }


    }
}
