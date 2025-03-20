Feature: Feature1

A short summary of the feature

Scenario Outline: Total bill for a group ordering starters, mains, and drinks based on order time
    Given as a restaurant owner I know the cost for <eachstarter>, <eachmain>, and <eachdrink>
    When group of people  orders <orderedTime>, starters <starterCount> ,mains <mainCount>, and drinks <drinkcount>
    And I check the <orderedTime> and apply discount on drinks if ordered within the discount time else discount won't apply
    Then the total bill should include the cost of starters, mains, and drinks along with <serviceCharge>
    And I assert the <actualAmount> with <expectedAmount>

    

    Examples:
      | eachstarter | eachmain | eachdrink | orderedTime              | discountforDrinks | starterCount | mainCount | drinkcount | expectedAmount |
      | 4.00        | 7.00     | 2.50      | 2025-03-17T17:00:00.317z | 30                | 4            | 4         | 4          | 56.10          |
      | 4.00        | 7.00     | 2.50      | 2025-03-19T18:55:23.317z | 30                | 4            | 4         | 4          | 56.10          |
      | 4.00        | 7.00     | 2.50      | 2025-03-20T20:09:23.317z | 0                 | 4            | 4         | 4          | 59.4           |

  
  

  Scenario Outline: Calculate total correct bill for group_one who orders with discount and group_two who orders without discount
  Given a First group  people orders before seven pm  following:
    | Item    | Quantity |Price | orderedTime              |
    | Starter | 1        |4.00  | 2025-03-19T18:30:23.317z |
    | Main    | 2        |7.00  | 2025-03-19T18:25:23.317z |
    | Drinks  | 2        |2.50  | 2025-03-19T18:10:23.317z |
  
  And a Second group people orders after  seven pm the following:
    | Item    | Quantity|Price | orderedTime              |
    | Starter | 0       |4.00  | 2025-03-20T20:09:23.317z |
    | Main    | 2       |7.00  | 2025-03-20T20:09:23.317z |
    | Drinks  | 2       |2.50  | 2025-03-20T20:09:23.317z |
    #(2×2.5−30%+2×7+1×4+10%=23.65)( 2×2.5+2×7+10%=20.9)= 44.55
  When I get the subtotal bill for  first and second group 
  Then I assert the expected result with the actual total:
    | expectedresult|
    | 44.55         |
