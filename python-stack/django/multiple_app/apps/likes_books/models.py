from django.db import models

class User(models.Model):
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)
    email = models.EmailField(max_length=255)
    created_at = models.DateField(auto_now_add=True)
    updated_at = models.DateField(auto_now=True)

    def __repr__(self):
        return "<User {}: {}>".format(self.id, (self.first_name + " " +self.last_name))

class Book(models.Model):
    name = models.CharField(max_length=255)
    desc = models.CharField(max_length=255)
    created_at = models.DateField(auto_now_add=True)
    updated_at = models.DateField(auto_now=True)
    uploaded_by = models.ForeignKey(User, related_name='has_uploaded')
    liked_by = models.ManyToManyField(User, related_name='liked_books')

    def __repr__(self):
        return "<Book {}: {}>".format(self.id, self.name)