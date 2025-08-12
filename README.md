# Retail Sales Statistics Calculator - User Guide

## Getting Started

Welcome! This application helps you analyze your retail sales data and calculate important statistics. Here's how to use it:

## Running the Application

1. Open a command prompt or terminal
2. Navigate to the folder containing the application files
3. Type: `dotnet run`
4. Press Enter

## Using the Menu

The application will show you a simple menu with 5 options:

**Option 1: Average earnings for a range of years**
- Choose this to find the average sales amount across multiple years
- You'll be asked to enter a start year and end year
- Example: Enter 2020 and 2023 to get average sales from 2020 to 2023

**Option 2: Standard deviation within a specific year**
- This shows how much your sales varied during one particular year
- Enter the year you want to analyze
- Higher numbers mean more variation in your daily sales

**Option 3: Standard deviation for a range of years**
- Similar to option 2, but covers multiple years
- Enter start and end years to see sales variation across that period
- Useful for understanding long-term sales consistency

**Option 4: Show all data**
- Displays all your sales records in an easy-to-read format
- Shows each sale with its date and amount in the format: dd/MM/yyyy##amount
- Great for reviewing your complete sales history

**Option 5: Exit**
- Closes the application

## Sample Data

The application comes with sample sales data from 2022 to help you test the features. You can try any of the calculations using year 2022 to see how it works.

## Data Format

The application expects sales data in the following format:
```
31/03/2022##287.50
15/04/2022##156.75
28/04/2022##345.20
```

Where:
- Date is in dd/MM/yyyy format
- ## separates the date from the amount
- Amount is a decimal number

## Tips
A
- For best results with the sample data, use year 2022 in your calculations
- The application handles invalid dates and amounts automatically
- All monetary amounts are displayed with two decimal places
- Data is sorted by date for easy reading

## Need Help?

If you get a "No data found" message, make sure you're entering years that match your data. The sample data only contains records from 2022.

Happy analyzing!
