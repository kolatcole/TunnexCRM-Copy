using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.Domains
{
    public class CartService : ICartService
    {

        private readonly IRepo<Item> _iRepo;
        private readonly IRepo<Cart> _cRepo;

        public CartService(IRepo<Item> iRepo, IRepo<Cart> cRepo)
        {
            _iRepo = iRepo;
            _cRepo = cRepo;
        }
        public async Task<int> SaveCart(Cart data)
        {
            int CID = await _cRepo.insertAsync(data);
            List<Item> items = new List<Item>();

            decimal amount = 0;
            foreach (var item in data.Items)
            {
                item.CartID = CID;
                amount += item.Amount;
                items.Add(item);
            }

            await _iRepo.insertListAsync(items);

            // update cart to add total amount

            data.ID = CID;

            data.Amount = amount;
            await _cRepo.updateAsync(data);
            return CID;
        }

    }
}
