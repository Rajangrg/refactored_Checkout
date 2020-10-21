
using Checkout.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Checkout.Tests
{
    [TestFixture]
    public class TillTest
    {
        ProductCalculator checkoutTill;

        [SetUp]
        public void SetUp()
        {
            checkoutTill = new ProductCalculator();
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProductDB.json"); //using ProductDb to replicate the Database
            var reader = new StreamReader(filePath);
            var jsonStr = reader.ReadToEnd();
            checkoutTill.SetProductPrice(jsonStr);
        }

        [Test]
        public void Given_Checkout_Till_ShoulBe_0_WithoutItem()
        {
            //Assert
            Assert.That(checkoutTill.CalculateTotalPrice(), Is.EqualTo(0));
        }

        [Test]
        public void Given_A_TotalPrice_ShouldBe_50()
        {
            //Act
            checkoutTill.ScanProductItem("A");
            //Assert
            Assert.That(checkoutTill.CalculateTotalPrice(), Is.EqualTo(50));
        }

        [Test]
        public void Given_AB_TotalPrice_ShouldBe_80()
        {
            //Act
            checkoutTill.ScanProductItem("A");
            checkoutTill.ScanProductItem("B");

            //Assert
            Assert.That(checkoutTill.CalculateTotalPrice(), Is.EqualTo(80));
        }

        [Test]
        public void Given_CDBA_TotalPrice_ShouldBe_115()
        {
            //Act
            checkoutTill.ScanProductItem("C");
            checkoutTill.ScanProductItem("D");
            checkoutTill.ScanProductItem("B");
            checkoutTill.ScanProductItem("A");
            //Assert
            Assert.That(checkoutTill.CalculateTotalPrice(), Is.EqualTo(115));
        }

        [Test]
        public void Given_TwoItemsOfTypeA_TotalPrice_ShouldBe_100()
        {
            //Act
            checkoutTill.ScanProductItem("A");
            checkoutTill.ScanProductItem("A");
            //Assert
            Assert.That(checkoutTill.CalculateTotalPrice(), Is.EqualTo(100));
        }


        [Test]
        public void Given_TwoItemsOfTypeB_TotalPrice_ShouldBe_45()
        {
            //Act
            checkoutTill.ScanProductItem("B");
            checkoutTill.ScanProductItem("B");
            //Assert
            Assert.That(checkoutTill.CalculateTotalPrice(), Is.EqualTo(45));
        }


        public void Given_ThreeItemsOfTypeA_TotalPrice_ShouldBe_130()
        {
            //Act
            checkoutTill.ScanProductItem("A");
            checkoutTill.ScanProductItem("A");
            checkoutTill.ScanProductItem("A");
            //Assert
            Assert.That(checkoutTill.CalculateTotalPrice(), Is.EqualTo(130));
        }

        [Test]
        public void Given_TwoAaItems_TotalPrice_ShouldBe_50()
        {
            //Act
            checkoutTill.ScanProductItem("A");
            checkoutTill.ScanProductItem("a");
            //Assert
            Assert.That(checkoutTill.CalculateTotalPrice(), Is.EqualTo(50));
        }

    }
}
