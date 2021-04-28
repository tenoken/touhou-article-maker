using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TouhouArticleMaker.Domain;
using TouhouArticleMaker.Shared;

namespace TouhouArticleMaker.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void Should_ReturnTrue_When_Given_ValidCard()
        {
            //Arrange
            var title = new Title("The Embodiment of Scarlet Devil");
            var developer = new Title("Team Shanghai Alice");
            var publisher = new Title("Team Shanghai Alice");
            var released = DateTime.Now;
            var genre = new Title("Vertical Danmaku Shooting Game");
            var validation = new EntityValidation();
            var platforms = new Title("Windows XP");
            var requirements = new Title("Pentium 500MHz");

            //platforms.Add(new Title("Windows XP"));
            //requirements.Add(new Title("Pentium 500MHz"));
            
            //Act
            var sut = new Card( 
                    title, 
                    developer, 
                    publisher, 
                    released, 
                    genre, 
                    platforms, 
                    requirements, 
                    validation);
            //Assert
            Assert.IsTrue(sut.IsValid);
        }

        [TestMethod]
        public void Should_ReturnTrue_When_Given_InvalidCard()
        {
            //Arrange
            var title = new Title("The Embodiment of Scarlet Devil");
            var developer = new Title("Team Shanghai Alice");
            var publisher = new Title("Team Shanghai Alice");
            var released = DateTime.MaxValue;
            var genre = new Title("Vertical Danmaku Shooting Game");
            var validation = new EntityValidation();
            var platforms = new Title("Windows XP");
            var requirements = new Title("Pentium 500MHz");

            //platforms.Add(new Title("Windows XP"));
            //requirements.Add(new Title("Pentium 500MHz"));
            
            //Act
            var sut = new Card( 
                    title, 
                    developer, 
                    publisher, 
                    released, 
                    genre, 
                    platforms, 
                    requirements, 
                    validation);
            //Assert
            Assert.IsFalse(sut.IsValid);
        }
    }
}