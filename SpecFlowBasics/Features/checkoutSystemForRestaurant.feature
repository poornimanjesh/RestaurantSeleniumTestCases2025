Feature: Calculate Total Bill for a Group Ordering Starters, Mains, and Drinks Based on Order Time

  As a restaurant owner
  I want to ensure the checkout system correctly calculates the total bill
  So that customers are charged accurately based on their orders and discounts

  Rules:
    - Starters cost £4.00 each.
    - Mains cost £7.00 each.
    - Drinks cost £2.50 each.
    - Drinks ordered before 19:00 receive a 30% discount.
    - A 10% service charge is applied to the total cost of food (starters and mains).

 
  
  
  

	

  Scenario Outline: Calculate correct bill for a group of 4 with one member canceling their order who came before 19:00

  # Initial Order for 4 People
  Given  Four people  group orders the following:
     | Item    | Quantity |Price | orderedTime              |
     | Starter | 4        |4.00  | 2025-03-19T18:30:23.317z |
     | Main    | 4        |7.00  | 2025-03-19T18:25:23.317z |
     | Drinks   | 4        |2.50  | 2025-03-19T18:10:23.317z |
  Then the total bill should be calculated as follows:
    | Total|
    | 56.10|

  # One Member Cancels Their Order
  Given one member of the group cancels their order:
   | Item    | Quantity |Price | orderedTime              |
   | Starter | 3        |4.00  | 2025-03-19T18:30:23.317z |
   | Main    | 3        |7.00  | 2025-03-19T18:25:23.317z |
   | Drinks   | 3        |2.50  | 2025-03-19T18:10:23.317z |
  Then the final total bill should be deducted as follows:
     | Total |
     | 42.075 |



 