using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderForm
{
  public class Customer {
   [Key]
   public string CustomerID { get; set; }

    public string Name { get; set; }

    public Customer() {
    }

    public Customer(string CustomerID, string name) {
      this.CustomerID = CustomerID;
      this.Name = name;
    }

    public override bool Equals(object obj) {
      var customer = obj as Customer;
      return customer != null &&
            CustomerID == customer.CustomerID &&
             Name == customer.Name;
    }

    public override int GetHashCode() {
      var hashCode = 1479869798;
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomerID);
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
      return hashCode;
    }
        public int OrderID { get; set; }
        [Required]
        public virtual Order Order { get; set; }

    }
}
