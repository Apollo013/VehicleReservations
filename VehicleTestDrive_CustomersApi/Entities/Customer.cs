using System.ComponentModel.DataAnnotations;

namespace VehicleTestDrive_CustomersApi.Entities
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
