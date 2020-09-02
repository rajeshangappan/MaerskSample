

# Promotion Sample:
-	Before selling the order apply the promotions and then give the discount to that order.
# IndustryEngine (Class):
-	Main class for promotion engine.
-	It has product manager and promotion manager class
# ProductManager(Class):
-	Maintain the products and details.
# Promotionmanager(Class):
-	Maintain the promotion’s and apply that promotion before the sale.
# Model:
# Product (Class):
-	Product details.
# Promotion (Class):
|     Property Name         |     Usage                                                                                                                  |     Implemented                 |
|---------------------------|----------------------------------------------------------------------------------------------------------------------------|---------------------------------|
|     ProductNames          |     List of products comes under this promotion.                                                                           |     Yes                         |
|     IsComboOffer          |     Is combo offer or single product offer.                                                                                |     Yes                         |
|     Count                 |     For single product offer we should mention the counts of the product.     For Combo offer always it should be 1.       |     Yes                         |
|     DiscountPercentage    |     For single product offer, if product count exceeds that minimum limit   then, we should apply this promotion.          |     No. Feature enhancement     |
|     OfferPrice            |     Promotion offer price for the product                                                                                  |     Yes                         |
|     MinCount              |     If product X, cross the min count limits then percentage wise   promotion will apply.                                  |     No, Feature enhancement     |
|     Priority              |     If same product has more than one promotion, then depends on the   priority value will apply that promotion.           |     No, Feature enhancement.    |
# Logics:
- When apply the promotion we have below implementation’s
In Promotion manager we have method “ApplyPromotions”. In this we have below methods to achive the promotion engine.
ApplyUniqueOffer(orders, promodict) – single product offer
ApplyComboOffer(orders, promodict) – combo product offer
ApplyRemainProductValue(orders, promodict) – If offer is not suitable to any product, then apply the unit price and add that price to order item.

# Feature enhancement:
- Create the promotion types and depends on the type will apply the promotion.
- Give the priority to all promotion and apply the promotion depends on the prority.

Output and test results added in output folder

