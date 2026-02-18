<script lang="ts">
  import { input } from "./input";
  import type { HTMLInputAttributes } from "svelte/elements";

  type Props = HTMLInputAttributes;
  let { class: className = "", ...props }: Props = $props();
</script>

<input dir="auto" class={input({ className: className?.toString() })} {...props} />
