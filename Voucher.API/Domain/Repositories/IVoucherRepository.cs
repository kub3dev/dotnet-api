using System;
using Voucher.API.Data.Models;

namespace Voucher.API.Domain.Repositories;

public interface IVoucherRepository : IDatabaseRepository<VoucherModel>
{

}
