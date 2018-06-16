from django.db import models

class Book(models.Model):
    name = models.CharField(max_length=255)
    desc = models.TextField()
    created_at = models.DateField(auto_now_add=True)
    updated_at = models.DateField(auto_now=True)
    notes = models.TextField(null=True,blank=True)

    def __repr__(self):
        return "<Book {}: {}>".format(self.id,self.name)

class Author(models.Model):
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)
    email = models.EmailField(max_length=255)
    created_at = models.DateField(auto_now_add=True)
    updated_at = models.DateField(auto_now=True)
    books = models.ManyToManyField(Book, related_name="written_by")

    def __repr__(self):
        return "<Author {}: {}>".format(self.id,(self.first_name + " "+ self.last_name))