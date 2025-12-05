using Store.Api.Dtos.CustomerDto;
using Store.Api.Models;

public static class CustomerMapping
{

    public static Customer ToModel(CustomerCreateDto dto)
    {
        return new Customer
        {
            Name = dto.Name,
            Phone = dto.Phone,
            Address = dto.Address,
            TotalDebt = 0,
            Sales = new List<Sale>(),
            Payments = new List<Payment>()
        };
    }

    // Model -> ReadDto
    public static CustomerReadDto ToReadDto(Customer customer)
    {
        return new CustomerReadDto
        {
            Id = customer.Id,
            Name = customer.Name,
            Phone = customer.Phone,
            Address = customer.Address,
            TotalDebt = customer.TotalDebt
        };
    }

    // UpdateDto -> Model (update qilish uchun)
    public static void UpdateModel(Customer customer, CustomerUpdateDto dto)
    {
        customer.Name = dto.Name;
        customer.Phone = dto.Phone;
        customer.Address = dto.Address;
        // TotalDebtni o'zgartirmaymiz, u Payment va Salelar orqali boshqariladi
    }

}
