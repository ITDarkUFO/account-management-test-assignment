using AccountManagement.Domain.Entities;

namespace AccountManagement.Infrastructure.SeedData
{
    public class SeedDataProvider
    {
        private static readonly List<string> _firstNames = ["Иван", "Алексей", "Михаил", "Дмитрий", "Артём", "Николай", "Андрей", "Сергей", "Василий", "Григорий", "Александр", "Пётр", "Константин", "Олег", "Виктор", "Юрий", "Роман", "Владимир", "Максим", "Евгений"];

        private static readonly List<string> _lastNames = ["Иванов", "Петров", "Сидоров", "Васильев", "Кузнецов", "Попов", "Смирнов", "Павлов", "Новиков", "Морозов", "Соловьёв", "Фёдоров", "Белов", "Орлов", "Марков", "Зайцев", "Григорьев", "Медведев", "Николаев", "Ефимов"];

        private static readonly List<string> _middleNames = ["Иванович", "Алексеевич", "Дмитриевич", "Сергеевич", "Андреевич", "Васильевич", "Михайлович", "Николаевич", "Юрьевич", "Владимирович", "Григорьевич", "Петрович", "Константинович", "Олегович", "Викторович", "Артёмович", "Максимович", "Евгеньевич", "Романович", "Павлович"];

        private static readonly List<string> _emails = ["ivanov@mail.com", "petrov@gmail.com", "sidorov@yahoo.com", "vasilev@outlook.com", "kuznetsov@mail.ru", "popov@gmail.com", "smirnov@yandex.ru", "pavlov@outlook.com", "novikov@gmail.com", "morozov@mail.com", "soloviev@outlook.com", "fedorov@yahoo.com", "belov@yandex.ru", "orlov@gmail.com", "markov@outlook.com", "zaytsev@mail.ru", "grigorev@gmail.com", "medvedev@yandex.ru", "nikolaev@outlook.com", "efimov@gmail.com"];

        private static readonly List<string> _phoneNumbers = ["79991234567", "79876543210", "79111223344", "79222334455", "79333445566", "79444556677", "79555667788", "79666778899", "79777889900", "79888990011", "79990011223", "79112345678", "79223456789", "79334567890", "79445678901", "79556789012", "79667890123", "79778901234", "79889012345", "79990123456"];

        private static readonly List<string> _passportNumbers = ["1234 567890", "2345 678901", "3456 789012", "4567 890123", "5678 901234", "6789 012345", "7890 123456", "8901 234567", "9012 345678", "0123 456789", "1234 678901", "2345 789012", "3456 890123", "4567 901234", "5678 012345", "6789 123456", "7890 234567", "8901 345678", "9012 456789", "0123 567890"];

        private static readonly List<string> _addresses = ["ул. Пушкина, д. 10, кв. 15, Москва", "пр. Ленина, д. 5, кв. 4, Санкт-Петербург", "ул. Горького, д. 12, кв. 8, Казань", "ул. Мира, д. 20, кв. 22, Нижний Новгород", "пр. Победы, д. 8, кв. 17, Екатеринбург", "ул. Севастопольская, д. 45, кв. 3, Новосибирск", "ул. Чехова, д. 14, кв. 10, Ростов-на-Дону", "ул. Лермонтова, д. 32, кв. 5, Воронеж", "ул. Карла Маркса, д. 25, кв. 18, Челябинск", "пр. Кирова, д. 13, кв. 9, Уфа", "ул. Строителей, д. 40, кв. 1, Краснодар", "ул. Советская, д. 7, кв. 16, Тюмень", "ул. Крылова, д. 19, кв. 12, Пермь", "пр. Калинина, д. 30, кв. 11, Омск", "ул. Фрунзе, д. 11, кв. 4, Рязань", "ул. Восхода, д. 22, кв. 13, Саратов", "ул. Шевченко, д. 9, кв. 2, Волгоград", "ул. Кольцова, д. 3, кв. 7, Архангельск", "ул. Горячая, д. 21, кв. 6, Хабаровск", "ул. Тверская, д. 27, кв. 5, Самара"];

        public static IEnumerable<User> GetSeedUsers()
        {
            Random rnd = new(0);

            List<User> users = [];

            for (int i = 0; i < 10; i++)
            {
                users.Add(new()
                {
                    FirstName = _firstNames[i],
                    LastName = _lastNames[i],
                    MiddleName = _middleNames[i],
                    Email = _emails[i]
                });
            }

            for (int i = 0; i < 10; i++)
            {
                users.Add(new()
                {
                    PhoneNumber = _phoneNumbers[i]
                });
            }

            for (int i = 10; i < 20; i++)
            {
                users.Add(new()
                {
                    FirstName = _firstNames[i],
                    LastName = _lastNames[i],
                    MiddleName = _middleNames[i],
                    Birthday = DateOnly.FromDayNumber(rnd.Next(715500, 739220)),
                    PassportNumber = _passportNumbers[i],
                    PhoneNumber = _phoneNumbers[i],
                    Email = rnd.Next(3) == 0 ? _emails[i] : null,
                    Address = rnd.Next(3) == 0 ? _addresses[i] : null,
                });
            }

            for (int i = 0; i < 30; i++)
            {
                users[i].Id = -i - 1;
            }

            return users;
        }
    }
}
