﻿using GymManagement.Domain.Subscriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagement.Infraestructure.Subscriptions.Persistence;

public class SusbcriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(s => s.Id)
            .ValueGeneratedNever();

        builder.Property("_adminId").HasColumnName("AdminId");

        builder.Property(s => s.SubscriptionType)
                .HasConversion(
                subscriptionType => subscriptionType.Value,
                value => SubscriptionType.FromValue(value)
            );
    }
}
