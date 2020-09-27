# DiscountCalculator
An configurable engine which applies promotional rates at the time of checkout.

This is a rate calculator engine which applies discounted rates to orders. 

The offers can be easily configured in json file. (As of currently implemention the offers are hard coded in function, but offers json can be easily read from local folder and deserialised into Offers collection rpoviding same output).

New offer can be added, removed or updated in offers json.

Offers have a proprty called isActive inroder to maintain if a order is active or not.

Offers also have a property called Priority so that if two offers collide then which one should be given more prefrence.

For eg.
Offer 1- 3 A - 130

Offer 2 - 5 A - 200

If input order is 10 A, then if offer 1 has more priority (1 being highest) then calcuation will be 10/3 -> 3 * 130 + 1 * 50. Where 50 is default price of A.

If input order is 10 A, then if offer 2 has more priority (1 being highest) then calcuation will be 10/5 -> 2 * 200.


Solution has a swagger endpoint to provide order input and see the result.

The endpoints and currently sync but can be made async for better performnace.
