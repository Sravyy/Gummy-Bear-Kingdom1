using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GummyBearKingdom.Models
{
    [Table("Reviews")]
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string Author { get; set; }
        public int Rating { get; set; }
        public string Content_Body { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public override bool Equals(System.Object otherReview)
        {
            if (!(otherReview is Review))
            {
                return false;
            }
            else
            {
                Review newReview = (Review)otherReview;
                bool EqualId = this.ReviewId.Equals(newReview.ReviewId);
                bool EqualAuthor = this.Author.Equals(newReview.Author);
                bool content = this.Content_Body.Equals(newReview.Content_Body);
                bool rating = this.Rating.Equals(newReview.Rating);
                bool prodId = this.ProductId.Equals(newReview.ProductId);


                return (EqualId && EqualAuthor && content && rating && prodId);
            }
        }

        public override int GetHashCode()
        {
            return this.ReviewId.GetHashCode();
        }
    }
}
