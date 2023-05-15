CREATE TABLE ratings (
    user_id UUID NOT NULL,
    movie_id INT NOT NULL,
    rating INT NOT NULL,
    PRIMARY KEY(user_id, movie_id)
);

CREATE TABLE comments (
    comment_id SERIAL PRIMARY KEY,
    user_id UUID NOT NULL,
    movie_id INT NOT NULL,
    comment TEXT
);

CREATE TABLE movie_lists (
    user_id UUID NOT NULL,
    list_id SERIAL PRIMARY KEY,
    list_name VARCHAR(255) NOT NULL,
    movie_id INT NOT NULL
);

CREATE TABLE follower (
    user_id UUID NOT NULL,
    follows_user_id UUID NOT NULL,
    PRIMARY KEY(user_id, follows_user_id)
);
