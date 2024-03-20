using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Payments.API.Public.ShoppingCart;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Dtos.TourExecutionsDTO;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.API.Public.TourExecuting;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.Core.UseCases.Authoring;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Explorer.Tours.Core.UseCases.Administration
{
    public class TourStatisticsService: ITourStatisticsService
    {
        private readonly ITourPurchaseTokenService _tourPurchaseTokenService;
        private readonly IMapper _mapper;
        private readonly ITourExecutionService _tourExecutionService;
        private readonly ITourPointExecutionService _tourPointExecutionService;
        private readonly ITourService _tourService;
        private readonly IEncounterExecutionService _encounterExecutionService;

        public TourStatisticsService(ITourPurchaseTokenService tourPurchaseTokenService, IMapper mapper, ITourExecutionService tourExecutionService,ITourPointExecutionService tourPointExecutionService ,ITourService tourService, IEncounterExecutionService encounterExecutionService) { 

            this._tourPurchaseTokenService = tourPurchaseTokenService;
            this._mapper = mapper;
            this._tourExecutionService = tourExecutionService;
            this._tourPointExecutionService = tourPointExecutionService;
            this._tourService =tourService;
            this._encounterExecutionService = encounterExecutionService;


        }

        //getNumberOfPurchasedToursByAuthor
        public int GetNumberOfPurchaseByAuthor(int authorId)
        {

            List<TourDTO> purchasedTours = new List<TourDTO>();
            purchasedTours = _tourPurchaseTokenService.GetAllPurchasedToursByAuthor(authorId);
            purchasedTours = purchasedTours.Distinct().ToList();
            return purchasedTours.Count;

        }
        public List<TourDTO> GetPurchasedToursByAuthor(int authorId)
        {

            List<TourDTO> purchasedTours = new List<TourDTO>();
            purchasedTours = _tourPurchaseTokenService.GetAllPurchasedToursByAuthor(authorId);
            return purchasedTours.Distinct().ToList();

        }

        public int GetNumberOfCompletedByAuthor(int authorId)
        {
            List<TourDTO> purchasedTours = new List<TourDTO>();
            purchasedTours = _tourPurchaseTokenService.GetAllPurchasedToursByAuthor(authorId);
            int count = 0;
            foreach (var tour in purchasedTours)
            {
                if (_tourExecutionService.IsTourFinished(tour.Id))
                {
                    count++;
                }
            }
            return count;

        }

        public int GetNumberOfStartedByAuthor(int authorId)
        {
            List<TourDTO> purchasedTours = new List<TourDTO>();
            purchasedTours = _tourPurchaseTokenService.GetAllPurchasedToursByAuthor(authorId);
            int count = 0;
            foreach (var tour in purchasedTours)
            {
                if (_tourExecutionService.IsTourStarted(tour.Id))
                {
                    count++;
                }
            }
            return count;

        }

        public int GetNumberOfPurchaseByTour(int authorId,int tourId)
        {
            int count = 0;

            List<TourDTO> purchasedTours = new List<TourDTO>();
            purchasedTours = _tourPurchaseTokenService.GetAllPurchasedToursByAuthor(authorId);
            foreach (TourDTO tour in purchasedTours) {
                if (tour.Id==tourId) {
                    count++;
                }
            }
            return count;

        }

        public int GetNumberOfStartedByTour(int authorId,int tourId)
        {
            List<TourDTO> purchasedTours = new List<TourDTO>();
            purchasedTours = _tourPurchaseTokenService.GetAllPurchasedToursByAuthor(authorId);
            int count = 0;
            foreach (var tour in purchasedTours)
            {
                if (_tourExecutionService.IsTourStarted(tour.Id) && tour.Id==tourId)
                {
                    count++;
                }
            }
            return count;

        }

        public int GetNumberOfCompletedByTour(int authorId,int tourId)
        {
            List<TourDTO> purchasedTours = new List<TourDTO>();
            purchasedTours = _tourPurchaseTokenService.GetAllPurchasedToursByAuthor(authorId);
            int count = 0;
            foreach (var tour in purchasedTours)
            {
                if (_tourExecutionService.IsTourFinished(tour.Id) && tour.Id==tourId)
                {
                    count++;
                }
            }
            return count;

        }

        public List<double> GetVisitedTourPointPercentage(int authorId, int tourId)
        {

            List<double> percentagesForTourPoints = new List<double>();

            TourDTO tourDto = new TourDTO();

            List<TourDTO> purchasedTours = new List<TourDTO>();
            purchasedTours = _tourPurchaseTokenService.GetAllPurchasedToursByAuthor(authorId);
            foreach (TourDTO tour in purchasedTours)
            {
                if (tour.Id == tourId)
                {
                    tourDto = tour;
                }
            }

            //za jednu turu svaki execution
            List<TourExecutionDto> tourExecutions = _tourExecutionService.GetAllExecutionsByTour(tourId);
            List<int> touristIds = new List<int>();
            foreach (TourExecutionDto tourExecution in tourExecutions)
            {
                touristIds.Add(tourExecution.UserId);
            }

            touristIds = touristIds.Distinct().ToList();

            foreach (TourPointDto tourPoint in tourDto.TourPoints)
            {
                double countVisited = 0;
                foreach (int id in touristIds)
                {
                    if (_tourPointExecutionService.isTourPointCompletedByTourist(id, tourPoint.Id))
                    {
                        countVisited++;
                    }
                }
                double percentage = (countVisited / touristIds.Count) * 100;

                percentagesForTourPoints.Add(percentage);
            }

            return percentagesForTourPoints;

        }




        public List<int> GetMaxPercentage(int authorId)
        {
            //lista za postotke, imace 4 elementa (0-25%....)
            List<int> numberOfPassedParts = new List<int>();
            int firstQuarter = 0;
            int secondQuarter = 0;
            int thirdQuarter = 0;
            int lastQuarter = 0;

            //sve kupljene ture ovog autora
            List<TourDTO> purchasedTours = new List<TourDTO>();
            purchasedTours = _tourPurchaseTokenService.GetAllPurchasedToursByAuthor(authorId);
            purchasedTours = purchasedTours.Distinct().ToList();

            int numberOfTourPoints = 0;
            foreach (TourDTO tourDto in purchasedTours)
            {

                numberOfTourPoints = tourDto.TourPoints.Count;

                //svi njeni executioni
                List<TourExecutionDto> tourExecutions = _tourExecutionService.GetAllExecutionsByTour(tourDto.Id);
                List<int> touristIds = new List<int>();
                List<long> executionIds = new List<long>();
                //svi turisti
                foreach (TourExecutionDto tourExecution in tourExecutions)
                {
                    touristIds.Add(tourExecution.UserId);
                    executionIds.Add((long)tourExecution.Id);
                    touristIds = touristIds.Distinct().ToList();
                }


                foreach (int id in touristIds)
                {
                    int maxTourPointId = _tourPointExecutionService.getMaxCompletedTourPointPerTourist(id, executionIds);
                    int numberOfPassedPoints = maxTourPointId - tourDto.TourPoints[0].Id;
                    double percentage = ((double)numberOfPassedPoints / (double)numberOfTourPoints) * 100;
                    if (percentage <= 25)
                    {
                        firstQuarter++;
                    }
                    if (percentage <= 50 && percentage > 25)
                    {
                        secondQuarter++;
                    }

                    if (percentage <= 75 && percentage > 50)
                    {
                        thirdQuarter++;
                    }
                    if (percentage <= 100 && percentage > 75)
                    {
                        lastQuarter++;
                    }

                }
            }

            numberOfPassedParts.Add(firstQuarter);
            numberOfPassedParts.Add(secondQuarter);
            numberOfPassedParts.Add(thirdQuarter);
            numberOfPassedParts.Add(lastQuarter);

            return numberOfPassedParts;
        }

       // za encounter
        public List<double> GetTourPointEncounterPercentage(int authorId, int tourId)
        {

            List<double> percentagesForTourPoints = new List<double>();

            TourDTO tourDto = new TourDTO();

            List<TourDTO> purchasedTours = new List<TourDTO>();
            purchasedTours = _tourPurchaseTokenService.GetAllPurchasedToursByAuthor(authorId);
            foreach (TourDTO tour in purchasedTours)
            {
                if (tour.Id == tourId)
                {
                    tourDto = tour;
                }
            }
            //za jednu turu svaki execution
            List<TourExecutionDto> tourExecutions = _tourExecutionService.GetAllExecutionsByTour(tourId);
            List<int> touristIds = new List<int>();
            foreach (TourExecutionDto tourExecution in tourExecutions)
            {
                touristIds.Add(tourExecution.UserId);
            }

            touristIds = touristIds.Distinct().ToList();

            foreach (TourPointDto tourPoint in tourDto.TourPoints)
            {
                double countVisited = 0;
                foreach (int id in touristIds)
                {
                    if (_encounterExecutionService.IsEncounterForTourPointCompleted(id, tourPoint.Id))
                    {
                        countVisited++;
                    }
                }
                double percentage = (countVisited / touristIds.Count) * 100;

                percentagesForTourPoints.Add(percentage);
            }

            return percentagesForTourPoints;

        }

    }
}
