using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GummyBearKingdom.Models.Repositories
{
    public interface IReviewRepository
    {
        IQueryable<Review> Reviews { get; }
        Review Save(Review Review);
        Review Edit(Review Review);
        void Remove(Review Review);
    }
}
