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

        [Theory]
        [Trait("Repositories", "Cart")]
        [InlineData(1)]
        public void when_GetCart_with_userId_arg_and_cart_exist_should_return_user_cart(int userId)
        {
            //Arrange
            //var cart = _fixture.Create<Cart>();
            //cart.Id = 1;
            //cart.UserId=1;
            //var cart1 = _fixture.Create<Cart>();

            //_dbContext.Carts.Add(cart1);
            //_dbContext.Carts.Add(cart);
            _dbContext.SaveChanges();

            //Act
            var actual = _cartRepo.GetCart(userId, true);

            //Assert
            userId.Should().Be(actual.UserId);

            actual.CartItems.Should().NotBeEmpty();
        }

        [Theory]
        [Trait("Repositories", "Cart")]
        [InlineData(100)]
        public void when_GetCart_with_userId_arg_and_no_cart_exist_should_create_cart_with_no_item(int userId)
        {

            //Arrange


            //Verify
            var anyCart=_dbContext.Carts.Any(x => x.UserId==userId);

            Assert.False(anyCart);

            //Act
            var act =_cartRepo.GetCart(userId,true);

            //Assert
            act.Should().NotBeNull();
            act.CartItems.Should().BeEmpty();
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


        [Theory]
        [Trait("Repositories", "Cart")]
        [InlineData(12,4)]
        public void when_DeleteCartItem_and_cartItem_exist_should_return_1(int productId, int cartId)
        {
            //Arrange
            //All data needed here are in the startup seed data
            
            //Act
            int actual=_cartRepo.DeleteCartItem(productId, cartId);
            _cartRepo.Commit();

            var check = _cartRepo.GetCartItemByProductIdCartId(productId, cartId);
            
            //Assert
            actual.Should().Be(1);
            check.Should().BeNull();
        }

        [Theory]
        [Trait("Repositories", "Cart")]
        [InlineData(1,1)]
        public void when_DeleteCartItem_and_no_cartItem_exist_should_throws_invalidOperationException(int productId, int cartId)
        {
            //Arrange

            //Act
            var act =()=> _cartRepo.DeleteCartItem(productId,cartId);

            //Assert
            act.Should().Throw<InvalidOperationException>().Which.Message.Should().Be("Ce produit n'existe pas");
        }

        [Theory]
        [Trait("Repositories", "Cart")]
        [InlineData(12,4,15)]
        public void when_UpdateCartItemQty_and_cartItem_exist_should_return_1(int productId,int cartId,int qty)
        {
            //Arrange

            //Act
            int actual = _cartRepo.UpdateCartItemQty(productId, cartId,qty);
            _cartRepo.Commit();

            var updated = _cartRepo.GetCartItemByProductIdCartId(productId, cartId);

            //Assert
            actual.Should().Be(1);
            updated.Quantity.Should().Be(15);
        }
    }
}
