<script setup lang="ts">
const tickets = ref([
  {
    "id": "f1e1f7a8-19e7-40cb-b72f-c79c5a649c70",
    "customerId": "cf7d7cb8-d1af-4823-961f-7ab03466a2bc",
    "employeeId": "00000000-0000-0000-0000-000000000000",
    "relatedTicketId": "00000000-0000-0000-0000-000000000000",
    "createdDate": "2025-01-10T09:15:34.334787",
    "reason": "Request for Refund",
    "status": 1,
    "description": "Customer requests a refund for a double charge.",
    "response": "Refund processed."
  },
  {
    "id": "3b1d4c32-83c1-42c5-88cf-768fa7c1f4ab",
    "customerId": "57b5c6f4-90c8-4f1e-bff9-16f34c972f2b",
    "employeeId": "a84738f3-d10d-49d8-8f6c-1b3f4f8b7c0f",
    "relatedTicketId": "00000000-0000-0000-0000-000000000000",
    "createdDate": "2025-01-11T14:22:10.334787",
    "reason": "Login Issue",
    "status": 0,
    "description": "User unable to log into their account.",
    "response": ""
  },
  {
    "id": "9a4c1b3e-52a2-4c9d-91dc-761f2a529e72",
    "customerId": "e7b92f38-4b6c-4dc4-842f-54f6172c6b79",
    "employeeId": "b973a8f6-f89c-472f-9f82-76dc3c34858e",
    "relatedTicketId": "3b1d4c32-83c1-42c5-88cf-768fa7c1f4ab",
    "createdDate": "2025-01-11T15:30:45.334787",
    "reason": "Escalation for Login Issue",
    "status": 2,
    "description": "Login issue escalated to IT support.",
    "response": "Resolved. Credentials reset."
  },
  {
    "id": "c2e6b5f8-d53d-40eb-88f4-fac2d89a6c60",
    "customerId": "8a49e30e-d753-44cc-b3eb-9634cb4bf98c",
    "employeeId": "00000000-0000-0000-0000-000000000000",
    "relatedTicketId": "00000000-0000-0000-0000-000000000000",
    "createdDate": "2025-01-12T08:45:30.334787",
    "reason": "Billing Discrepancy",
    "status": 0,
    "description": "Customer reports incorrect billing amount.",
    "response": ""
  },
  {
    "id": "bf84c4a2-731d-4bd4-8a0e-7c6a3d4b967e",
    "customerId": "9723c4c7-8d4b-4bc8-a6f4-783a2e6b91c2",
    "employeeId": "3f9e0c7e-7284-4dcb-8b74-5a1b2c6d3f08",
    "relatedTicketId": "00000000-0000-0000-0000-000000000000",
    "createdDate": "2025-01-12T10:20:50.334787",
    "reason": "Feature Request",
    "status": 1,
    "description": "Customer requests a new feature for the app.",
    "response": "Acknowledged and under review."
  },
  {
    "id": "7c4f8b9e-91f2-4e3a-bc8f-47d82f6c1b39",
    "customerId": "61a3e8d4-7b28-47b5-a69f-4a3d4c9b8f73",
    "employeeId": "f2b6c4d8-3e17-4cb8-8a1f-83b4e7c9f08a",
    "relatedTicketId": "00000000-0000-0000-0000-000000000000",
    "createdDate": "2025-01-12T11:15:12.334787",
    "reason": "Technical Query",
    "status": 2,
    "description": "Customer has a technical question regarding software integration.",
    "response": "Question answered with detailed guide."
  },
  {
    "id": "6a1f7b9e-d2b4-452a-91f7-5e4c7b8f3e91",
    "customerId": "a3b8f4e7-1b5a-487f-b8a7-9d4c1b7e6f4c",
    "employeeId": "d8f3b9e7-84a3-482f-87b1-3f6a7e2b91c4",
    "relatedTicketId": "7c4f8b9e-91f2-4e3a-bc8f-47d82f6c1b39",
    "createdDate": "2025-01-12T12:00:30.334787",
    "reason": "Follow-Up on Technical Query",
    "status": 1,
    "description": "Customer requires further clarification on previous query.",
    "response": "Additional clarification provided."
  },
  {
    "id": "3f8e1c7a-748f-423b-8a1e-2c4d6b9f71f3",
    "customerId": "1b4c7a9e-3e8f-4c7b-a5f2-8d1e4b9f7c3e",
    "employeeId": "6f9b3c7e-1f8a-47b9-8e7c-3b4d7f8c1e91",
    "relatedTicketId": "00000000-0000-0000-0000-000000000000",
    "createdDate": "2025-01-12T13:45:00.334787",
    "reason": "Complaint About Service",
    "status": 0,
    "description": "Customer reports poor service experience.",
    "response": ""
  },
  {
    "id": "4e1f7b8c-9e4a-482f-b7a3-2d6b9f7c1e5a",
    "customerId": "2f9e3c7a-84b6-4b7f-a5f1-7b1c4e9f8a3d",
    "employeeId": "7b8f3e1c-94f7-47a9-8c7e-3f1b9e2c7a84",
    "relatedTicketId": "00000000-0000-0000-0000-000000000000",
    "createdDate": "1000-01-13T09:30:30.334787",
    "reason": "Request for Upgrade",
    "status": 1,
    "description": "Customer wants to upgrade their subscription plan.",
    "response": "Upgrade processed successfully."
  },
])

const reasons = ref([
  {
    value: "fehlercode",
    description: "Fehlercode"
  },
  {
    value: "hardwareproblem",
    description: "Hardwareproblem"
  },
  {
    value: "support",
    description: "Support"
  },
  {
    value: "softwareUpdates",
    description: "Software-Updates"
  },
  {
    value: "sonstiges",
    description: "Sonstiges"
  }
])


const filter = ref(null)
const filtered = computed(() => {
  return tickets.value
      .sort((a, b) => {
        if (a.status !== b.status) {
          return a.status - b.status;
        }
        return new Date(a.createdDate).getTime() - new Date(b.createdDate).getTime()
      })
      .filter(t => !filter.value || t.status == filter.value);
});


const status = {
  0: 'Nicht Zugewiesen',
  1: 'Zugewiesen',
  2: 'Warteliste',
  3: 'Geschlossen',
  9999: 'Alle'
}
</script>

<template>
  <div class="flex gap-2 flex-col">
    <div class="mt-5 flex grow justify-end gap-2">
      <UiSelect v-model="filter">
        <UiSelectTrigger>
          <UiSelectValue placeholder="Filter Status" />
        </UiSelectTrigger>
        <UiSelectContent>
          <UiSelectGroup>
            <UiSelectItem
                class="font-semibold"
                :key="useId()"
                :value="Object.keys(status)[index]"
                v-for="(stat,index) in status">
              {{stat}}
            </UiSelectItem>
          </UiSelectGroup>
        </UiSelectContent>

      </UiSelect>
    </div>
    <div class="flex justify-end">
       <span class="font-semibold text-sm">
      {{filtered.length}} Tickets
    </span>
    </div>
  </div>

  <div v-if="tickets" class="mt-4">
    <div class="flex gap-4 flex-col w-full">
      <UiCard class="relative" v-for="ticket in filtered" :key="ticket.id">
        <UiCardHeader class="flex flex-row justify-between">
          <UiCardTitle class="text-lg">
            {{ticket.reason}}
          </UiCardTitle>
          <div class="absolute top-4 right-4 font-semibold  flex flex-col">
            <span>
            Status: {{ticket.status}}
            </span>
            <span>

            Assigneed: {{ ticket.employeeId != "00000000-0000-0000-0000-000000000000" && ticket.employeeId }}
            </span>
          </div>
        </UiCardHeader>
        <UiCardContent>
          <div>
            <p class="leading-7 [&:not(:first-child)]:mt-6">
              {{ticket.description}}
            </p>
          </div>

        </UiCardContent>
        <UiCardFooter>
          <span class="text-sm font-semibold text-muted-foreground">
          {{timeAgo(new Date(ticket.createdDate))}}
          </span>
        </UiCardFooter>
      </UiCard>
    </div>
  </div>
  <div v-else class="grow grid place-content-center h-full text-lg font-semibold">
        Meine Tickets
  </div>
</template>
