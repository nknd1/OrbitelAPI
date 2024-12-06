namespace OrbitelApi.Models.Dtos;

public record ClientRegisterDto
(
     string FullName, // ФИО клиента
     DateOnly? DateOfBirth, // Дата рождения
     string SeriesPass, // Серия паспорта
     string NumberPass, // Номер паспорта
     string IssuedBy, // Кем выдан паспорт
     DateOnly IssueDate, // Дата выдачи паспорта
     string AddressRegistration, // Адрес регистрации
     string Inn, // ИНН
     string Phone, // Телефон
     string Login, // Логин
     string? Email, // Почта (необязательно)
     string PasswordHash
);