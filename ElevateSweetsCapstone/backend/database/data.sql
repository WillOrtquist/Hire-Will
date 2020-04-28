-- *****************************************************************************
-- This script contains INSERT statements for populating tables with seed data
-- *****************************************************************************

BEGIN TRANSACTION;

-- default username of 'user' and default password of 'greatwall'
INSERT INTO users
  (username,password,salt,role)
VALUES
  ('name', 'KgrolkOWjHuNvQtFrGwZOqGm5qs=', 'V7CHRJ6vltc=', 'User');

-- STANDARD CAKE INSERT STATEMENTS -- 

INSERT INTO standard_cakes (name, price, style, size, flavor, frosting, filling, description, image_path)
VALUES ('Holy Sheet Cake!', 75, 'Sheet cake', 'Full-pan', 'Yellow', 'Hazelnut Buttercream', 'None', 'A great basic cake for any event. Delicious hazelnut buttercream icing pairs perfectly with yellow sponge cake.', 'sheet-cake-yellow-chocolate-frosting.png');

INSERT INTO standard_cakes (name, price, style, size, flavor, frosting, filling, description, image_path)
VALUES ('Garden Party Sheet Cake', 40, 'Sheet cake', 'Half-pan', 'Lemon Poppyseed', 'Vanilla Buttercream', 'None', 'A beautiful cake for any occassion. Sweet lemon poppyseed sponge cake topped with vanilla buttercream and decorated with lovely buttercream roses.', 'sheet-cake-vanilla-roses.png');

INSERT INTO standard_cakes (name, price, style, size, flavor, frosting, filling, description, image_path)
VALUES ('Elegant Wedding Cake', 150, 'Layer Cake', '3-tier', 'Chocolate', 'Fondant', 'None', 'A picture-perfect wedding cake to enhance your special day and impress your guests. Three tiers of chocolate covered in white fondant and decorated with edible icing pearls.', 'layer-cake-three-tier-wedding.png');

INSERT INTO standard_cakes (name, price, style, size, flavor, frosting, filling, description, image_path)
VALUES ('Keep You Awake Espresso Cake', 50, 'Layer Cake', '8-inch', 'Espresso', 'Chocolate Ganache', 'Cream', 'Take a sensory journey with this luscious speciality cake that will keep you up thinking about it all night long. Espresso-flavored cake layered with mocha and vanilla cream, topped with a layer of chocolate ganache, and patted with chocolate coffee crumbles.', 'layer-cake-chocolate-espresso.png');

INSERT INTO standard_cakes (name, price, style, size, flavor, frosting, filling, description, image_path)
VALUES ('Devilishly Decadent Cupcake', 4, 'Cupcake', 'Standard', 'Chocolate', 'Chocolate Buttercream', 'Raspberry', 'Satisfy your sweet tooth with this delectably devilish cupcake. Chocolate cake with raspberry filling topped with white and milk chocolate buttercream icing and a fresh raspberry.', 'cupcake-chocolate-cream.png');

INSERT INTO standard_cakes (name, price, style, size, flavor, frosting, filling, description, image_path)
VALUES ('Good Enough to Drink Cupcake', 4, 'Cupcake', 'Standard', 'Chai', 'Nutmeg Buttercream', 'None', 'Drink your chai and eat it, too, with this deliciously spiced cupcake. Chai cake with nutmeg icing sprinkled with cinnamon and sugar.', 'cupcake-chai-latte.png');

INSERT INTO standard_cakes (name, price, style, size, flavor, frosting, filling, description, image_path)
VALUES ('Celebrate Cookie Cake', 40, 'Cookie Cake', '12-inch', 'Chocolate chip', 'Chocolate', 'None', 'Make any day a celebration with this delicious cookie cake. Chocolate chip cookie outlined with chocolate icing and sprinkled with edible multi-colored confetti.', 'cookie-cake-confetti.png');

INSERT INTO standard_cakes (name, price, style, size, flavor, frosting, filling, description, image_path)
VALUES ('Peanut Butter Bonanza Cookie Cake', 70, 'Cookie Cake', '18-inch', 'Peanut Butter', 'Chocolate', 'Reeses Pieces', 'Have a blast with this fantastically flavored cookie cake. Peanut butter cookie mixed with Reeses Pieces, outlined with chocolate icing, and sprinkled with edible multi-colored confetti.', 'cookie-cake-peanut-butter.png');

INSERT INTO standard_cakes (name, price, style, size, flavor, frosting, filling, description, image_path)
VALUES ('Magical Dimension Ice Cream Cake', 50, 'Ice Cream Cake', '8-inch', 'Chocolate', 'Whipped Cream', 'Strawberry', 'Enjoy a bit of magic with this beautifully layered ice cream cake. Chocolate ice cream with a center layer of strawberry ice cream covered in whipped cream frosting and topped with a layer of chocolate hard shell and multi-colored sprinkles.', 'ice-cream-cake-layered-hard-shell.png');

INSERT INTO standard_cakes (name, price, style, size, flavor, frosting, filling, description, image_path)
VALUES ('Black-&-White Delight Ice Cream Cake', 50, 'Ice Cream Cake', '8-inch', 'Cookies and Cream', 'Whipped Cream', 'Cookie', 'This family-favorite ice cream cake will make your day all the sweeter. Cookies-and-cream ice cream with a chocolate cake base layer, topped with whipped cream frosting, drizzled with chocolate hard shell, outlined with a circle of chocolate icing shells, and wedged with whole Oreo cookies.', 'ice-cream-cake-oreo.png');

-- CUSTOM CAKE INSERT STATEMENTS --

-- Styles --

INSERT INTO styles (available, style, price)
VALUES ( 1, 'Sheet cake', 1)

INSERT INTO styles (available, style, price)
VALUES ( 1, 'Layer cake', 1)

INSERT INTO styles (available, style, price)
VALUES ( 1, 'Cupcake', 1)

-- Fillings --

INSERT INTO fillings (available, filling)
VALUES ( 1, 'None')

INSERT INTO fillings (available, filling)
VALUES ( 1, 'Raspberry')

INSERT INTO fillings (available, filling)
VALUES (1, 'Blueberry')

INSERT INTO fillings (available, filling)
VALUES (1, 'Orange')

INSERT INTO fillings (available, filling)
VALUES (1, 'Custard Cream')

INSERT INTO fillings (available, filling)
VALUES (1, 'Vanilla Cream')

INSERT INTO fillings (available, filling)
VALUES (1, 'Chocolate Cream')

-- Flavors --

INSERT INTO flavors (available, flavor)
VALUES ( 1, 'Vanilla')

INSERT INTO flavors (available, flavor)
VALUES ( 1, 'Chocolate')

INSERT INTO flavors (available, flavor)
VALUES ( 1, 'Yellow')

INSERT INTO flavors (available, flavor)
VALUES (1, 'Red Velvet')

INSERT INTO flavors (available, flavor)
VALUES (1, 'Lemon Poppyseed')

INSERT INTO flavors (available, flavor)
VALUES (1, 'Pineapple')

INSERT INTO flavors (available, flavor)
VALUES (1, 'Peanut Butter')

-- Frostings --

INSERT INTO frostings (available, frosting)
VALUES ( 1, 'Vanilla Buttercream')

INSERT INTO frostings (available, frosting)
VALUES ( 1, 'Chocolate Buttercream')

INSERT INTO frostings (available, frosting)
VALUES ( 1, 'Hazelnut Buttercream')

INSERT INTO frostings (available, frosting)
VALUES ( 1, 'Strawberry Buttercream')

INSERT INTO frostings (available, frosting)
VALUES ( 1, 'Lavendar Buttercream')

INSERT INTO frostings (available, frosting)
VALUES ( 1, 'Chocolate Ganache')

INSERT INTO frostings (available, frosting)
VALUES ( 1, 'Cream Cheese Icing')

-- Sizes --

INSERT INTO sizes (available, size, base_price)
VALUES ( 1, 'Quarter-pan', 30)

INSERT INTO sizes (available, size, base_price)
VALUES ( 1, 'Half-pan', 40)

INSERT INTO sizes (available, size, base_price)
VALUES ( 1, 'Full-pan', 75)

INSERT INTO sizes (available, size, base_price)
VALUES ( 1, '2-tier', 100)

INSERT INTO sizes (available, size, base_price)
VALUES ( 1, '3-tier', 150)

INSERT INTO sizes (available, size, base_price)
VALUES ( 1, '4-tier', 200)

INSERT INTO sizes (available, size, base_price)
VALUES ( 1, 'Mini', 2)

INSERT INTO sizes (available, size, base_price)
VALUES ( 1, 'Standard', 4)

INSERT INTO sizes (available, size, base_price)
VALUES ( 1, 'Jumbo', 6)

-- Styles and Sizes Associative Table --

INSERT INTO style_size (style_id, size_id)
VALUES (1,1), (1,2), (1,3), (2,4), (2,5), (2,6), (3,7), (3,8), (3,9)

--INSERT INTO custom_cakes (name, price, style_id, size_id, flavor_id, frosting_id, filling_id, description, image_path)
--VALUES ('Holy Sheet Cake!', 45,  , 1 , 1, 1, 1, 'A great basic cake for any event. Delicious hazelnut buttercream frosting pairs perfectly with yellow sponge cake.', 'sheet-cake-yellow-chocolate-frosting.png');

--select name, styles.style, sizes.size, flavors.flavor, frostings.frosting, fillings.filling, description, image_path from cakes 
--join styles on cakes.style_id = styles.id
--join sizes on cakes.size_id = sizes.id
--join flavors on cakes.flavor_id = flavors.id
--join frostings on cakes.frosting_id = frostings.id
--join fillings on cakes.filling_id = fillings.id


--ORDER INSERT STATEMENTS--

-- pending --
INSERT INTO orders (cake_name, cake_quantity, style, size, flavor, frosting, filling, cake_message, order_total, order_status, customer_name, phone_number, email, pickup_datetime)
VALUES ('Holy Sheet Cake!', 1, 'Sheet cake', 'Full-pan', 'Yellow', 'Hazelnut Buttercream', 'None', null, 75, 'pending', 'Xanth Hively', '555-5309', 'lilxanth@gmail.com', '2020-04-23 15:00:00.000');

INSERT INTO orders (cake_name, cake_quantity, style, size, flavor, frosting, filling, cake_message, order_total, order_status, customer_name, phone_number, email, pickup_datetime)
VALUES ('Custom', 1, 'Sheet cake', 'Half-pan', 'Chocolate', 'Cream Cheese Icing', 'Orange', 'Happy Anniversary', 45, 'pending', 'Desiree Markle', '555-2694', 'accnttime@gmail.com', '2020-04-20 13:00:00.000');

INSERT INTO orders (cake_name, cake_quantity, style, size, flavor, frosting, filling, cake_message, order_total, order_status, customer_name, phone_number, email, pickup_datetime)
VALUES ('Custom', 1, 'Sheet cake', 'Quarter-pan', 'Peanut Butter', 'Chocolate Buttercream', 'None', 'Happy Birthday, Meghan!', 55, 'pending', 'Gloria Rose', '555-2981', 'rosiesmosie@gmail.com', '2020-04-25 11:00:00.000');

INSERT INTO orders (cake_name, cake_quantity, style, size, flavor, frosting, filling, cake_message, order_total, order_status, customer_name, phone_number, email, pickup_datetime)
VALUES ('Custom', 1, 'Layer cake', '3-tier', 'Chocolate', 'Chocolate Ganache', 'Custard Cream', null, 150, 'pending', 'Angela Spivey', '555-4409', 'angelaspiv@gmail.com', '2020-04-30 10:00:00.000');

-- completed --
INSERT INTO orders (cake_name, cake_quantity, style, size, flavor, frosting, filling, cake_message, order_total, order_status, customer_name, phone_number, email, pickup_datetime)
VALUES ('Keep You Awake Espresso Cake', 1, 'Layer Cake', '8-inch', 'Espresso', 'Chocolate Ganache', 'Cream', null, 75, 'completed', 'Dan Smythe', '555-4783', 'tantime@gmail.com', '2020-04-08 15:00:00.000');

INSERT INTO orders (cake_name, cake_quantity, style, size, flavor, frosting, filling, cake_message, order_total, order_status, customer_name, phone_number, email, pickup_datetime)
VALUES ('Celebrate Cookie Cake', 1, 'Cookie Cake', '12-inch', 'Chocolate Chip', 'Chocolate', 'None', null, 40, 'completed', 'Archibald Lyle', '555-3019', 'archie@gmail.com', '2020-04-19 12:00:00.000');

INSERT INTO orders (cake_name, cake_quantity, style, size, flavor, frosting, filling, cake_message, order_total, order_status, customer_name, phone_number, email, pickup_datetime)
VALUES ('Black-and White Delight! Ice Cream Cake', 1, 'Ice Cream Cake', '8-inch', 'Cookies and Cream', 'Whipped Cream', 'Cookie', null, 50, 'completed', 'Julia Rogers', '555-4928', 'jjrogers@gmail.com', '2020-04-09 11:00:00.000');

-- ready --
INSERT INTO orders (cake_name, cake_quantity, style, size, flavor, frosting, filling, cake_message, order_total, order_status, customer_name, phone_number, email, pickup_datetime)
VALUES ('Custom', 1, 'Layer cake', '2-tier', 'Red Velvet', 'Cream Cheese Icing', 'None', null, 75, 'ready', 'Daniel Jackson', '555-0001', 'drarcheology@gmail.com', '2020-04-17 15:00:00.000');

INSERT INTO orders (cake_name, cake_quantity, style, size, flavor, frosting, filling, cake_message, order_total, order_status, customer_name, phone_number, email, pickup_datetime)
VALUES ('Magical Dimension Ice Cream Cake', 1, 'Ice Cream Cake', '8-inch', 'Chocolate', 'Whipped Cream', 'Strawberry', null, 50, 'ready', 'Lucy Montgomery', '555-2398', 'canadianwriter@gmail.com', '2020-04-17 14:00:00.000');

INSERT INTO orders (cake_name, cake_quantity, style, size, flavor, frosting, filling, cake_message, order_total, order_status, customer_name, phone_number, email, pickup_datetime)
VALUES ('Custom', 1, 'Sheet cake', 'Half-pan', 'Pineapple', 'Vanilla Buttercream', 'None', 'Congratulations!', 45, 'ready', 'Tom Nook', '555-3498', 'islandguide@gmail.com', '2020-04-17 13:00:00.000');

-- canceled --
INSERT INTO orders (cake_name, cake_quantity, style, size, flavor, frosting, filling, cake_message, order_total, order_status, customer_name, phone_number, email, pickup_datetime)
VALUES ('Good Enough to Drink Cupcake', 1, 'Cupcake', 'Standard', 'Chai', 'Nutmeg Buttercream', 'None', null, 3, 'canceled', 'Debra Meyer', '555-2210', 'dmeyer@gmail.com', '2020-04-17 18:00:00.000');

INSERT INTO orders (cake_name, cake_quantity, style, size, flavor, frosting, filling, cake_message, order_total, order_status, customer_name, phone_number, email, pickup_datetime)
VALUES ('Custom', 1, 'Cupcake', 'Jumbo', 'Pineapple', 'Vanilla Buttercream', 'Chocolate Cream', null, 6, 'canceled', 'Jonnie Wrigley', '555-1146', 'jwrigley@gmail.com', '2020-04-16 15:00:00.000');


SELECT * from standard_cakes

SELECT * from orders

COMMIT TRANSACTION;
