# -*- coding: utf-8 -*-
# Generated by Django 1.10 on 2018-06-28 17:38
from __future__ import unicode_literals

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    dependencies = [
        ('campaigns', '0001_initial'),
    ]

    operations = [
        migrations.RemoveField(
            model_name='character',
            name='equipment',
        ),
        migrations.RemoveField(
            model_name='character',
            name='skills',
        ),
        migrations.RemoveField(
            model_name='character',
            name='stats',
        ),
        migrations.RemoveField(
            model_name='character',
            name='tools',
        ),
        migrations.RemoveField(
            model_name='npc',
            name='age',
        ),
        migrations.RemoveField(
            model_name='npc',
            name='alignment',
        ),
        migrations.RemoveField(
            model_name='npc',
            name='background',
        ),
        migrations.RemoveField(
            model_name='npc',
            name='char_class',
        ),
        migrations.RemoveField(
            model_name='npc',
            name='char_subclass',
        ),
        migrations.RemoveField(
            model_name='npc',
            name='equipment',
        ),
        migrations.RemoveField(
            model_name='npc',
            name='exp',
        ),
        migrations.RemoveField(
            model_name='npc',
            name='gender',
        ),
        migrations.RemoveField(
            model_name='npc',
            name='height',
        ),
        migrations.RemoveField(
            model_name='npc',
            name='level',
        ),
        migrations.RemoveField(
            model_name='npc',
            name='skills',
        ),
        migrations.RemoveField(
            model_name='npc',
            name='stats',
        ),
        migrations.RemoveField(
            model_name='npc',
            name='subrace',
        ),
        migrations.RemoveField(
            model_name='npc',
            name='tools',
        ),
        migrations.RemoveField(
            model_name='npc',
            name='weight',
        ),
        migrations.AlterField(
            model_name='campaign',
            name='owner',
            field=models.OneToOneField(on_delete=django.db.models.deletion.CASCADE, related_name='runs_campaigns', to='login_registration.User'),
        ),
        migrations.AlterField(
            model_name='character',
            name='age',
            field=models.IntegerField(blank=True, null=True),
        ),
        migrations.AlterField(
            model_name='character',
            name='in_campaign',
            field=models.ForeignKey(blank=True, null=True, on_delete=django.db.models.deletion.CASCADE, related_name='has_characters_in_campaigns', to='campaigns.Campaign'),
        ),
        migrations.AlterField(
            model_name='character',
            name='played_by',
            field=models.ForeignKey(blank=True, null=True, on_delete=django.db.models.deletion.CASCADE, related_name='has_characters', to='login_registration.User'),
        ),
    ]
