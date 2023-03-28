using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EgitoShopping.CartShop.Domain.Entities
{
    [Table("cart_header")]
    public class CartHeader
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }

        [Column("coupon_code")]
        public string CouponCode { get; set; }
    }
}
