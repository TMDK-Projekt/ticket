<script setup lang="ts">

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

</script>

<template>

  <UiDialog>

    <UiDialogTrigger>Ticket erstellen</UiDialogTrigger>

    <UiDialogContent>
      <UiDialogHeader>
        <UiDialogTitle>Ticket erstellen</UiDialogTitle>

        <UiLabel>Grund</UiLabel>
        <UiSelect>
          <UiSelectTrigger>
            <UiSelectValue placeholder="Grund" />
          </UiSelectTrigger>
          <UiSelectContent>
            <UiSelectGroup>
              <UiSelectLabel>Gründe</UiSelectLabel>
              <UiSelectItem v-for='reason in reasons' :key='reason.value' :value="reason.value">
                {{reason.description}}
              </UiSelectItem>
            </UiSelectGroup>
          </UiSelectContent>
        </UiSelect>

        <UiLabel>Beschreibung</UiLabel>
        <UiTextarea></UiTextarea>
      </UiDialogHeader>

      <UiDialogFooter>
        <UiButton>
          Speichern
        </UiButton>
      </UiDialogFooter>
    </UiDialogContent>

  </UiDialog>

</template>

<style scoped>

</style>