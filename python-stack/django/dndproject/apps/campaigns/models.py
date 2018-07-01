from __future__ import unicode_literals
from django.db import models
from picklefield.fields import PickledObjectField
from ..login_registration.models import User

class Campaign(models.Model):
    name = models.CharField(max_length=50)
    desc = models.CharField(max_length=150)
    owner = models.OneToOneField(User, on_delete=models.CASCADE, related_name="runs_campaigns")
    members = models.ManyToManyField(User, related_name="has_campaigns")

    def __repr__(self):
        return "<Campaign {} Name: {}, Owner: {}>".format(self.id, self.name,self.owner.username)
    
class Location(models.Model):
    name = models.CharField(max_length=100)
    desc = models.TextField()
    in_campign = models.ForeignKey(Campaign, on_delete=models.CASCADE, related_name="has_locations", db_constraint=False)
    country = models.CharField(max_length=100)

class NPC(models.Model):
    campaign = models.ForeignKey(Campaign, on_delete=models.CASCADE,related_name="has_npcs")
    name = models.CharField(max_length=100)
    race = models.CharField(max_length=30)
    personality = models.TextField(blank=True,null=True)
    desc = models.TextField(blank=True,null=True)
    flaws = models.TextField(blank=True,null=True)
    ideals = models.TextField(blank=True,null=True)

class Character(models.Model):
    played_by = models.ForeignKey(User, on_delete=models.CASCADE, related_name="has_characters", null=True, blank=True)
    in_campaign = models.ForeignKey(Campaign, on_delete=models.CASCADE, related_name="has_characters_in_campaigns",  null=True, blank=True)
    name = models.CharField(max_length=75)
    race = models.CharField(max_length=30)
    subrace = models.CharField(max_length=30,blank=True,null=True)
    char_class = models.CharField(max_length=30)
    char_subclass = models.CharField(max_length=50,blank=True,null=True)
    alignment = models.CharField(max_length=30)
    level = models.IntegerField()
    exp = models.IntegerField()
    background = models.CharField(max_length=30)
    age = models.IntegerField(blank=True,null=True)
    gender = models.CharField(max_length=20)
    height = models.IntegerField(blank=True,null=True)
    weight = models.IntegerField(blank=True,null=True)
    # stats = PickledObjectField(blank=True,null=True)
    # skills = PickledObjectField(blank=True,null=True)
    # tools = PickledObjectField(blank=True,null=True)
    # has_spells = models.ManyToManyField(Spell, related_name="used_by")
    # has_feats = models.ManyToManyField(Feat, related_name="used_by")
    # equipment = PickledObjectField(blank=True,null=True)
    personality = models.TextField(blank=True,null=True)
    desc = models.TextField(blank=True,null=True)
    flaws = models.TextField(blank=True,null=True)
    ideals = models.TextField(blank=True,null=True)

    def __repr__(self):
        return "<Character {} Name: {}, Played by: {}, Campaign: {}>".format(self.id, self.name,self.played_by.username,self.in_campaign.name)

class Note(models.Model):
    message = models.TextField()
    added_by = models.ForeignKey(User, on_delete=models.CASCADE,related_name="has_notes", null=True, blank=True)
    campaign = models.ForeignKey(Campaign, on_delete=models.CASCADE, related_name="notes", null=True, blank=True)
    created_at = models.DateField(auto_now_add=True)
