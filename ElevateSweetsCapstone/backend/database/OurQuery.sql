USE CakesDB

--INSERT INTO styles (available, style, price_multiplier)
--VALUES ( 1, 'Sheet cake', 1)

--INSERT INTO styles (available, style, price_multiplier)
--VALUES ( 1, 'Layer cake', 1)

--INSERT INTO styles (available, style, price_multiplier)
--VALUES ( 1, 'Cupcake', 1)

--INSERT INTO fillings (available, filling, price_multiplier)
--VALUES ( 1, 'Raspberry', 1)

--INSERT INTO fillings (available, filling, price_multiplier)
--VALUES ( 1, 'Raspberry', 1)

--INSERT INTO fillings (available, filling, price_multiplier)
--VALUES ( 1, 'None', 1)

--INSERT INTO frostings (available, frosting, price_multiplier)
--VALUES ( 1, 'Hazelnut Buttercream', 1)

--INSERT INTO sizes (available, size, price_multiplier)
--VALUES ( 1, 'Full-pan', 1)

--INSERT INTO sizes (available, size, price_multiplier)
--VALUES ( 1, 'Half-pan', 1)

--INSERT INTO sizes (available, size, price_multiplier)
--VALUES ( 1, '3-tier', 1)

--INSERT INTO sizes (available, size, price_multiplier)
--VALUES ( 1, 'Standard', 1)

--INSERT INTO sizes (available, size, price_multiplier)
--VALUES ( 1, '8-inch', 1)

--INSERT INTO sizes (available, size, price_multiplier)
--VALUES ( 1, '12-inch', 1)

--INSERT INTO sizes (available, size, price_multiplier)
--VALUES ( 1, '18-inch', 1)

--INSERT INTO style_size (style_id, size_id)
--VALUES (1, 1), (1,2)



--INSERT INTO cakes (name, price, style_id, size_id, flavor_id, frosting_id, filling_id, description, image_path)
--VALUES ('Holy Sheet Cake!', 45, 1 , 1 , 1, 1, 2, 'A great basic cake for any event. Delicious hazelnut buttercream icing pairs perfectly with yellow sponge cake.', 'sheet-cake-yellow-chocolate-frosting.png');

select name, styles.style, sizes.size, flavors.flavor, frostings.frosting, fillings.filling, description, image_path from cakes 
join styles on cakes.style_id = styles.id
join sizes on cakes.size_id = sizes.id
join flavors on cakes.flavor_id = flavors.id
join frostings on cakes.frosting_id = frostings.id
join fillings on cakes.filling_id = fillings.id

select * from cakes



--Full-pan
--Half-pan
--3-tier
--8-inch
--Standard
--Standard
--12-inch
--18-inch
--8-inch
--8-inch