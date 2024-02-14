﻿using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string imagem)
        {
            ValidateDomain(name, description, price, stock, imagem);
        }
        public Product(int id, string name, string description, decimal price, int stock, string imagem)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, description, price, stock, imagem);
        }
        public void Update(string name, string description, decimal price, int stock, string imagem, int categoryId)
        {
            ValidateDomain(name, description, price, stock, imagem);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string imagem)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required.");
            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description. Description is required.");
            DomainExceptionValidation.When(description.Length < 5,
                "Invalid description, too short, minimum 5 characters");
            DomainExceptionValidation.When(price < 0, "Invalid price value");

            DomainExceptionValidation.When(stock < 0, "Invalid stock value");

            DomainExceptionValidation.When(Image.Length < 250,
                "Invalid image name, too long, maximum 250 characters");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = imagem;
        }

        // Relacionando ao Category
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}