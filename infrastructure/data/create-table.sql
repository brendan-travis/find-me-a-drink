CREATE TABLE locations (
    name VARCHAR(50),
    category VARCHAR(50),
    url VARCHAR(50),
    date DATE,
    excerpt VARCHAR(250),
    thumbnail VARCHAR(250),
    lat VARCHAR(50),
    lng VARCHAR(50),
    address VARCHAR(250),
    phone VARCHAR(50),
    twitter VARCHAR(50),
    stars_beer VARCHAR(5),
    stars_atmosphere VARCHAR(5),
    stars_amenities VARCHAR(5),
    stars_value VARCHAR(5),
    tags VARCHAR(250),
    PRIMARY KEY (name)
)
