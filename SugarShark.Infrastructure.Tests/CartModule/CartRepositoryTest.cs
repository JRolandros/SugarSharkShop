using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using SugarShark.Domain.Entities;
using SugarShark.Infrastructure.CartModule.Repertories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarShark.Infrastructure.Tests.CartModule
{
    public class CartRepositoryTest
    {
        private readonly SugarSharkDbContext _dbContext;
        private readonly CartRepository _cartRepo;
        private readonly Fixture _fixture;
        public CartRepositoryTest()
        {
            _dbContext = SugarSharkInMemoryDbContext.GetSugarSharkDbContext();
            _cartRepo= new CartRepository(_dbContext);

            _fixture = new Fixture();
        }

        [Fact]
        [Trait("Repositories", "Cart")]
        public void when_GetCart_with_userId_arg_and_cart_exist_should_return_user_cart()
        {
            //Arrange
            var cart = _fixture.Create<Cart>();
            cart.Id = 1;
            cart.UserId=1;
            var cart1 = _fixture.Create<Cart>();

            _dbContext.Carts.Add(cart1);
            _dbContext.Carts.Add(cart);
            _dbContext.SaveChanges();

            //Act
            var actual = _cartRepo.GetCart(cart.UserId);

            //Assert
            Assert.Equal(cart, actual);
            actual.CartItems.Should().NotBeEmpty();
        }

        [Fact]
        [Trait("Repositories", "Cart")]
        public void when_GetCart_with_userId_arg_and_no_cart_exist_should_throws_InvalidOperationException()
        {

            //Arrange
            var cart = _fixture.Create<Cart>();
            cart.Id = 1;
            cart.UserId = 1;

            _dbContext.Carts.Add(cart);
            _dbContext.SaveChanges();

            //Act
            var act =()=> _cartRepo.GetCart(2);

            //Assert
            act.Should().Throw<InvalidOperationException>().Which.Message.Should().Be("Le panier est vide");
        }

        [Fact]
        [Trait("Repositories", "Cart")]
        public void when_AddCartItem_and_cart_exist_should_save_item_in_database_and_return_1()
        {
            //Arrange
            var cart = _fixture.Create<Cart>();
            cart.Id = 1;
            cart.UserId = 1;

            _dbContext.Carts.Add(cart);
            _dbContext.SaveChanges();

            var item=_fixture.Create<CartItem>();
            item.CartId=cart.Id;

            //Act
            int actual = _cartRepo.AddCartItem(item);
            _cartRepo.Commit();

            var savedItem=_dbContext.CartItems.First(x=>x.CartId==item.CartId && x.ProductId==item.ProductId);
            item.Id = savedItem.Id;

            //Assert
            actual.Should().Be(1);
            savedItem.Should().NotBeNull().And.Be(item);

        }

        [Fact]
        [Trait("Repositories", "Cart")]
        public void when_AddCartItem_and_no_cart_exist_should_throws_constraint_exception()
        {
            //Arrange

            var item = _fixture.Create<CartItem>();
            item.CartId = 3;

            //Act
            var act =()=> _cartRepo.AddCartItem(item);
            

            //Assert
            act.Should().Throw<Exception>().Which.Message.Should().Be("Violation de la constrainte de clé étranger");

        }


        [Fact]
        [Trait("Repositories", "Cart")]
        public void when_DeleteCartItem_and_cartItem_exist_should_return_1()
        {
            //Arrange
            var item1 = _fixture.Create<CartItem>();
            item1.Id = 3;
            var item2 = _fixture.Create<CartItem>();
            item2.Id = 4;
            var cart = new Cart() { CartItems = new List<CartItem> { item1, item2 } };
            cart.Id = 1;
            cart.UserId = 1;
            var item = _fixture.Create<CartItem>();
            item.CartId = cart.Id;

            _dbContext.Carts.Add(cart);
            _dbContext.CartItems.Add(item);
            _dbContext.SaveChanges();
            
            //Act
            int actual=_cartRepo.DeleteCartItem(item.Id);
            _cartRepo.Commit();

            var check = _dbContext.CartItems.FirstOrDefault(x => x.Id == item.Id);
            
            //Assert
            actual.Should().Be(1);
            check.Should().BeNull();
        }

        [Fact]
        [Trait("Repositories", "Cart")]
        public void when_DeleteCartItem_and_no_cartItem_exist_should_throws_invalidOperationException()
        {
            //Arrange
            var item1 = _fixture.Create<CartItem>();
            item1.Id = 3;
            var item2 = _fixture.Create<CartItem>();
            item2.Id = 4;
            var cart = new Cart() { CartItems=new List<CartItem> { item1,item2} };
            cart.Id = 1;
            cart.UserId = 1;
            var item = _fixture.Create<CartItem>();
            item.Id = 1;
            item.CartId = cart.Id;

            _dbContext.Carts.Add(cart);
            _dbContext.CartItems.Add(item);
            _dbContext.SaveChanges();

            //Act
            var act =()=> _cartRepo.DeleteCartItem(2);

            //Assert
            act.Should().Throw<InvalidOperationException>().Which.Message.Should().Be("Ce produit n'existe pas");
        }

        [Fact]
        [Trait("Repositories", "Cart")]
        public void when_UpdateCartItemQty_and_cartItem_exist_should_return_1()
        {
            //Arrange
            var cart = _fixture.Create<Cart>();
            cart.Id = 1;
            cart.UserId = 1;
            var item = _fixture.Create<CartItem>();
            item.CartId = cart.Id;
            item.Qantity = 10;

            _dbContext.Carts.Add(cart);
            _dbContext.CartItems.Add(item);
            _dbContext.SaveChanges();

            //Act
            int actual = _cartRepo.UpdateCartItemQty(item.Id,item.Qantity+5);
            _cartRepo.Commit();

            var updated = _dbContext.CartItems.First(x => x.Id == item.Id);
            //Assert
            actual.Should().Be(1);
            updated.Qantity.Should().Be(15);
        }
    }
}
