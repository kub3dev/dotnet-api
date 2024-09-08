using System;
using Voucher.API.Data.Models;
using Voucher.Core.Repositories;

namespace Voucher.API.Domain.Repositories;

public interface IVoucherRepository : IDatabaseRepository<VoucherModel>
{

}
