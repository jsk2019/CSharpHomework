using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderForm
{
  public class Goods {
    [Key]
    public string GoodsID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    
    public Goods() {
    }

    public Goods(string GoodsID, string name, double price) {
      this.GoodsID = GoodsID;
      this.Name = name;
      this.Price = price;
    }

    public override bool Equals(object obj) {
      var goods = obj as Goods;
      return goods != null &&
             GoodsID == goods.GoodsID &&
             Name == goods.Name;
    }

    public override int GetHashCode() {
      var hashCode = 1479869798;
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GoodsID);
      hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
      return hashCode;
    }
        public int OrderID { get; set; }
        [Required]
        public virtual OrderItem OrderItem { get; set; }
  }


}
