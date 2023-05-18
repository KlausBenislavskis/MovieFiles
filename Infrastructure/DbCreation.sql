CREATE TABLE users (
    user_id UUID PRIMARY KEY,
    user_name VARCHAR(255) NOT NULL
);
CREATE TABLE ratings (
    user_id UUID NOT NULL,
    movie_id INT NOT NULL,
    rating INT NOT NULL,
    PRIMARY KEY(user_id, movie_id),
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

CREATE TABLE comments (
    comment_id SERIAL PRIMARY KEY,
    user_id UUID NOT NULL,
    movie_id INT NOT NULL,
    comment TEXT,
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

CREATE TABLE movie_lists (
    user_id UUID NOT NULL,
    list_id SERIAL PRIMARY KEY,
    list_name VARCHAR(255) NOT NULL,
    movie_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

CREATE TABLE follower (
    user_id UUID NOT NULL,
    follows_user_id UUID NOT NULL,
    PRIMARY KEY(user_id, follows_user_id),
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (follows_user_id) REFERENCES users(user_id)
);

DROP VIEW IF EXISTS user_activities;
DROP TABLE IF EXISTS activities;
DROP TYPE IF EXISTS activity_type;

DROP INDEX IF EXISTS idx_activities_user_id;
DROP INDEX IF EXISTS idx_activities_followed_user_id;
DROP INDEX IF EXISTS idx_activities_movie_id;
DROP INDEX IF EXISTS idx_follower_user_id;

CREATE TABLE activities (
    activity_id SERIAL PRIMARY KEY,
    user_id UUID NOT NULL REFERENCES users(user_id),
    followed_user_id UUID REFERENCES users(user_id),
    activity_type VARCHAR(255) NOT NULL,
    movie_id INT,
    rating_value INT,
    comment_text TEXT,
    timestamp TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX idx_activities_user_id ON activities(user_id);
CREATE INDEX idx_activities_followed_user_id ON activities(followed_user_id);
CREATE INDEX idx_activities_movie_id ON activities(movie_id);
CREATE INDEX idx_follower_user_id ON follower(user_id);


CREATE VIEW user_activities AS
SELECT 
    u.user_name, 
    f.user_id, 
    a.activity_type, 
    a.movie_id, 
    a.rating_value, 
    a.comment_text, 
    fu.user_name as followed_user_name,
    a.timestamp
FROM 
    follower f
JOIN 
    users u ON u.user_id = f.user_id
JOIN 
    activities a ON a.user_id = f.user_id
LEFT JOIN
    users fu ON fu.user_id = a.followed_user_id
ORDER BY 
    a.timestamp DESC;

