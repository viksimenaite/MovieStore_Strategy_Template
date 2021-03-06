﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore_Strategy
{
    class LowPriceMovieStoreStrategy : MoviePriceStrategy
    {
        private readonly double kidsDiscount = 0.10;
        private readonly double loyalDiscount = 0.15;
        private readonly double PVM = 0.21;

        public double CountFees(Movie movie)
        {
            return movie.BasePrice * PVM;
        }

        public double DeterminePrice(Movie movie)
        {
            double price = movie.BasePrice; //base price
            if (movie.TotalNoOfPurchases > 80) //if movie is popular
            {
                price += 1.5;
            }

            if ((DateTime.Today.Year - movie.ReleaseDate.Year) < 2) //if movie is quite new
            {
                price += 1;
            }
            return price;
        }

        public double GetDiscount(Client client, Movie movie)
        {
            double discount = 0;
            if (client.TotalNoOfOrders > 10) //loyal client
            {
                discount = loyalDiscount;
            }

            if (client.CalculateAge() < 16) // discount for kids
            {
                discount += kidsDiscount;
            }

            return discount;
        }
    }
}
