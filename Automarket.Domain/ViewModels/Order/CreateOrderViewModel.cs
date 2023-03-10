using System.ComponentModel.DataAnnotations;

namespace Automarket.Domain.ViewModels.Order
{
    public class CreateOrderViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Количество")]
        [Range(1, 10, ErrorMessage = "Количество должно быть от 1 до 10")]
        public int Quantity { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Адрес и номер телефона")]
        [Required(ErrorMessage = "Укажите ваш адрес и номер телефона")]
        [MaxLength(200, ErrorMessage = "В поле должно быть меньше 200 символов")]
        public string Address { get; set; }
        
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Укажите имя")]
        [MaxLength(30, ErrorMessage = "Имя должно иметь длину меньше 30 символов")]
        [MinLength(3, ErrorMessage = "Имя должно иметь длину больше 3 символов")]
        public string FirstName { get; set; }
        
        [Display(Name = "Фамилия")]
        [MaxLength(50, ErrorMessage = "Фамилия должно иметь длину меньше 50 символов")]
        [MinLength(2, ErrorMessage = "Фамилия должно иметь длину больше 2 символов")]
        public string LastName { get; set; }
        
        [Display(Name = "Отчество")]
        [MaxLength(50, ErrorMessage = "Отчество должно иметь длину меньше 50 символов")]
        [MinLength(2, ErrorMessage = "Отчество должно иметь длину больше 2 символов")]
        public string MiddleName { get; set; }
    
        public long CarId { get; set; }
        
        public string Login { get; set; }
    }   
}